using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Shutdown_Schedular
{
    public partial class Form1 : Form
    {

        int hours = 0;
        int min = 0;
        int sec = 0;
        int totalSec = 0;
        bool isValid = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void BtAbort_Click(object sender, EventArgs e)
        {
            Process process = new System.Diagnostics.Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C shutdown -a";
            process.StartInfo = startInfo;
            process.Start();

            MessageBox.Show("Shutdown Aborted");
        }

        private void BtShutdown_Click(object sender, EventArgs e)
        {
            ConvertTimeToSec();

            if (isValid)
            {
                Process process = new System.Diagnostics.Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C shutdown -s -t " + totalSec;

                process.StartInfo = startInfo;
                process.Start();

                MessageBox.Show("Shutdown Scheduled for " + ConvertToHrsMinSec(hours, min, sec));
            }
            else
                isValid = true;
           

        }

        private void BtRestart_Click(object sender, EventArgs e)
        {
            ConvertTimeToSec();

            if (isValid)
            {
                Process process = new System.Diagnostics.Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C shutdown -r -t " + totalSec;
                process.StartInfo = startInfo;
                process.Start();

                MessageBox.Show("Restart Scheduled for " + ConvertToHrsMinSec(hours, min, sec));
            }
            else
                isValid = true;
           

        }


        private void TbHours_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbMin_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbSec_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConvertTimeToSec()
        {
            try
            {
                hours = Convert.ToInt32(tbHours.Text);
                min = Convert.ToInt32(tbMin.Text);
                sec = Convert.ToInt32(tbSec.Text);
            }
            catch(Exception e)
            {
                isValid = false;
                MessageBox.Show("Must be a Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            totalSec = (hours * 3600) + (min * 60) + sec;
        }

        private string ConvertToHrsMinSec(int hours, int min, int sec)
        {
            string hoursMinsSec;
            string stHours;
            string stMin;
            string stSec;

            if(min >= 60)
            {
                hours += (min / 60);
                min = min % 60;
            }

            if(sec >= 60)
            {
                min += (sec / 60);
                sec = sec % 60;
            }

            stHours = "" + hours;


            if (min > 9)
                stMin = "" + min;
            else
                stMin = "0" + min;

            if (sec > 9)
                stSec = "" + sec;
            else
                stSec = "0" + sec;

            hoursMinsSec = stHours + ":" + stMin + ":" + stSec;

            return hoursMinsSec;
        }

            

    }
}

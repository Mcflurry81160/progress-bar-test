using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progress_bar_test_3_dnf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Hide the progress bar initially
            progressBar1.Visible = false;
        }

        private void StartProcess_Click(object sender, EventArgs e)
        {
            //Start showing the progress bar now
            progressBar1.Visible = true;
            btnStartProcess.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 50;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //Add the work to do here
            //Reporting progress is not required as this is a marquee style progress bar
            Thread.Sleep(10000);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Minimum;

            btnStartProcess.Enabled = true;
            progressBar1.Visible = false;
            MessageBox.Show("Done!");
        }
    }
}

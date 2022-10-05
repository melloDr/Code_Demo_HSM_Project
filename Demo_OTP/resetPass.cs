using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_OTP
{
    public partial class resetPass : Form
    {
        int seconds = 10;
        public resetPass()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            CountDownTimer timer = new CountDownTimer();
            timer.SetTime(0, 10);
            timer.Start();
            timer.TimeChanged += () => lbCounter.Text = timer.TimeLeftMsStr;
            timer.CountDownFinished += () => lbCounter.Text = "Finish!";
            timer.CountDownFinished += () =>
            {

            };
            timer.StepMs = 77;
        }

        private void resetPass_Load(object sender, EventArgs e)
        {

        }
    }
}

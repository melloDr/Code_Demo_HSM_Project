using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_OTP
{
    public partial class Form1 : Form
    {
        String randomCode;
        public static String to;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void sendOTP()
        {
            String from, pass, messageBody;
            Random r = new Random();
            randomCode = (r.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = tbLogin.Text;
            from = "digitalsigttgh@gmail.com";
            pass = "qelwldzjuyngbczf";
            messageBody = "Your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Reseting Code";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtpClient.Send(message);
                lbInformation.Text = "Code Send Successfully!";
                //MessageBox.Show("Code Send Successfully!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            CountDownTimer timer = new CountDownTimer();
            timer.SetTime(1, 10);
            timer.Start();
            timer.TimeChanged += () => lbTimer.Text = timer.TimeLeftMsStr;
            timer.CountDownFinished += () => lbTimer.Text = "The OTP code has expired. Please login to try again!";
            timer.CountDownFinished += () =>
            {
                randomCode = "0";
                btLogin.Text = "Try again";
            };
            timer.StepMs = 77;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            sendOTP();
        }

        private void btVerify_Click(object sender, EventArgs e)
        {
            if (randomCode == tbVerify.Text)
            {
                to = tbLogin.Text;
                resetPass rp = new resetPass();
                this.Hide();
                rp.Show();

            }
            else
            {
                MessageBox.Show("OTP is wrong or has expired, please try again");
            }
        }

        private void tbVerify_TextChanged(object sender, EventArgs e)
        {
           

        }
    }
}

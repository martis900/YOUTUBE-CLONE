using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.IO;
namespace YouTUBE
{
    public partial class resetpassword : Form
    {
        string vercode;
        string emailas;

        public resetpassword()
        {
            InitializeComponent();
        }
        public string generateVerificationCode()
        {
            //generating verification code
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var vcode = new String(stringChars);
            return vcode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vercode = generateVerificationCode();
            //sending verification code to users email
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("asdfhacker.chat.app@gmail.com");
            mail.To.Add(textBox1.Text);
            mail.Subject = "Verification Code";
            mail.Body = string.Format("HI {0}. YOUR VERIFICATION CODE - {1}", textBox1.Text, vercode);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("asdfhacker.chat.app@gmail.com", "nesakysiuhahaha");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            emailas = textBox1.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == vercode)
            {
                newpassword frmNewPassword = new newpassword(emailas);
                frmNewPassword.ShowDialog();
            }
        }
    }
}

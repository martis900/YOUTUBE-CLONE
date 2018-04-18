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
    public partial class signUP : Form
    {
        public signUP()
        {
            InitializeComponent();
        }
        Regex mail = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckFields()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Login can not be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("E-mail can not be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Password can not be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Password can not be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mail.IsMatch(textBox4.Text))
            {
                MessageBox.Show("E-mail incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (CheckFields() == true)
            {
                //checking if registration data is unique or is not empty
                string komanda1 = string.Format("SELECT count(id) FROM logins WHERE UserName = '{0}';", textBox1.Text);
                string komanda2 = string.Format("SELECT count(id) FROM logins WHERE email = '{0}';", textBox4.Text);

                var connection = DBFunctions.OpenConnection(); //get connection to server
                if (connection == null) return;

                var cmd1 = DBFunctions.ExecuteSqlScalar(komanda1, connection);
                var cmd2 = DBFunctions.ExecuteSqlScalar(komanda2, connection);

                int countuser = Convert.ToInt32(cmd1);
                int countemail = Convert.ToInt32(cmd2);

                if (countuser != 0)
                {
                    MessageBox.Show("User with this username already exists");

                    label1.Enabled = true;
                    return;
                }

                if (countemail != 0)
                {
                    MessageBox.Show("User with this email already exists");

                    label1.Enabled = true;
                    return;
                }
                try
                {
                    sendRegInfoToDatabase(textBox1.Text, textBox2.Text, textBox4.Text, "red", 0);
                    MessageBox.Show("User created successfully!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Test");
                }
                
                
                this.ResetText();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong SIGN UP info");
            }

        }

        private void sendRegInfoToDatabase(string username, string password, string email, string color, int subs)
        {
            string sqlText = string.Format("INSERT INTO logins VALUES(null,'{0}','{1}','{2}','{3}',{4});", username, PasswordClass.GetMD5hash(textBox3.Text), email, color, subs);

            var connection = DBFunctions.OpenConnection(); //get connection to server
            if (connection == null) return;
            DBFunctions.ExecuteSqlNoReturn(sqlText, connection);
            connection.Close();
            connection.Dispose();
        }

        private void label11_Click(object sender, EventArgs e)
        {


        }
        public byte[] imageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();

            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private void signUP_Load(object sender, EventArgs e)
        {

        }
    }
}

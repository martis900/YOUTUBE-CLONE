using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTUBE
{
    public partial class signIN : Form
    {
        mainFORM prnt;

        public signIN()
        {
            InitializeComponent();
        }
        public signIN(mainFORM pfrm)
        {
            InitializeComponent();

            prnt = pfrm;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            signUP signup = new signUP();
            this.Close();
            signup.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            string sqlText = "select count(id) from logins where UserName='" + textBox1.Text + "';";
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;
            if ((long)DBFunctions.ExecuteSqlScalar(sqlText, connection) == 0)
            {
                MessageBox.Show("User does not exist");
                return;
            }

            sqlText = string.Format("select id,username,password,email,ChannelColour,subscribers from logins where Username='{0}' and Password='{1}';", textBox1.Text, PasswordClass.GetMD5hash(textBox2.Text));
            var reader = DBFunctions.ExecuteSqlSelect(sqlText, connection);
            if (reader == null) return;
            if (!reader.HasRows)
            {
                MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            userData user = new userData();
            while (reader.Read())
            {
                user.user_ID = (ulong)reader[0];
                user.user_username = reader[1].ToString();
                user.user_password = reader[2].ToString();
                user.user_email = reader[3].ToString();
                user.user_colour = reader[4].ToString();
                user.user_subscribers = reader[5].ToString();
            }
            reader.Close();
            reader.Dispose();
            connection.Close();
            connection.Dispose();
            //open main form
            prnt.loaduser(user);

            prnt.label2.Visible = false;

            prnt.panel2.Visible = true;

            prnt.label12.Text = user.user_username;
            Color red = Color.FromName(user.user_colour);
            prnt.label6.BackColor = red;
            prnt.active = true;

            if (prnt.Controls.ContainsKey("hmw"))
            {
                prnt.Controls.RemoveByKey("hmw");
                prnt.loadtrends();
            }
            if (prnt.Controls.ContainsKey("wthvid"))
            {
                prnt.loadtrends();
            }

            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            resetpassword rstpass = new resetpassword();
            rstpass.Show();
        }
    }
}

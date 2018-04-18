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
    public partial class newpassword : Form
    {
        string emailas;
        public newpassword(string emal)
        {

            InitializeComponent();
            emailas = emal;
        }
        string OldPassword;


        private void NewPassword_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                string sqlText = string.Format("select password from logins where email='{0}';", emailas);
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;
                OldPassword = (string)DBFunctions.ExecuteSqlScalar(sqlText, connection);

                sqlText = string.Format("UPDATE logins SET Password='{0}' WHERE Password='{1}';", PasswordClass.GetMD5hash(textBox2.Text), OldPassword);

                DBFunctions.ExecuteSqlNoReturn(sqlText, connection);
                connection.Close();
                connection.Dispose();
            }
        }
    }
}


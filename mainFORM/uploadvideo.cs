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
    public partial class uploadvideo : Form
    {
        public userData user;
        public uploadvideo(userData curuser)
        {
            InitializeComponent();
            user = curuser;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            string link;
            link = textBox2.Text.Replace("watch?v=","v/");

            if (CheckFields() == true)
            {
                //checking if registration data is unique or is not empty
                string komanda1 = string.Format("SELECT count(id) FROM videos WHERE videolink = '{0}';", textBox2.Text);

                var connection = DBFunctions.OpenConnection(); //get connection to server
                if (connection == null) return;

                var cmd1 = DBFunctions.ExecuteSqlScalar(komanda1, connection);

                int countlinks = Convert.ToInt32(cmd1);

                if (countlinks != 0)
                {
                    MessageBox.Show("This video already exists");
                    return;
                }
                try
                {
                    sendRegInfoToDatabase(user.user_ID,textBox1.Text,link,0,0,0,textBox3.Text, DateTime.Now);
                }
                catch (Exception)
                {
                    
                }
                MessageBox.Show("Video upoloaded successfully!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to upload video");
            }
        }
        private bool CheckFields()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Video title can not be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Video link can not be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void sendRegInfoToDatabase(ulong channelID, string name, string videolink, ulong views, ulong likes, ulong dislikes,string discription, DateTime uploadtime)
        {
            string sqlText = string.Format("INSERT INTO videos VALUES(null,{0},'{1}','{2}',{3},{4},{5},'{6}','{7}');",channelID,name,videolink,views,likes,dislikes,discription,uploadtime.ToString());

            var connection = DBFunctions.OpenConnection(); //get connection to server
            if (connection == null) return;
            DBFunctions.ExecuteSqlNoReturn(sqlText, connection);
            connection.Close();
            connection.Dispose();
        }
    }
}

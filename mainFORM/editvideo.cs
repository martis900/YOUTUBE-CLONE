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
    public partial class editvideo : Form
    {
        string link;

        public editvideo(string link)
        {
            InitializeComponent();
            this.link = link;
        }

        private void editvideo_Load(object sender, EventArgs e)
        {
            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            string sqlText2 = string.Format("SELECT name,videolink,description FROM videos WHERE videolink = '{0}'", link);
            var reader = DBFunctions.ExecuteSqlSelect(sqlText2, connectionn);
            if (reader == null) return;
            while (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
            }
            reader.Close();
            reader.Dispose();
        }


        private void label10_Click(object sender, EventArgs e)
        {
            try
            {
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;

                string sqlText = string.Format("UPDATE videos SET name='{0}',videolink = '{1}',description = '{2}' WHERE videolink='{3}';", textBox1.Text, textBox2.Text, textBox3.Text, link);

                DBFunctions.ExecuteSqlNoReturn(sqlText, connection);
                connection.Close();
                connection.Dispose();
                MessageBox.Show("Video was succsesfully updated!");
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Failed while updating video!");
            }
            

        }
    }
}

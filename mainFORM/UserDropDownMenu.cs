using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouTUBE
{
    public partial class UserDropDownMenu : UserControl
    {
        mainFORM prnt;
        public UserDropDownMenu(mainFORM prnt)
        {
            InitializeComponent();
            this.prnt = prnt;
        }
        private void SignOutBtn_Click(object sender, EventArgs e)
        {
            prnt.active = false;
            prnt.user = null;
            prnt.panel2.Visible = false;
            prnt.Controls.RemoveByKey("uddm");
            prnt.label2.Visible = true;

            if (prnt.Controls.ContainsKey("hmw"))
            {
                prnt.Controls.RemoveByKey("hmw");
                prnt.loadtrends();
            }
            if (prnt.Controls.ContainsKey("wthvid"))
            {
                prnt.loadtrends();
            }

            
        }

        private void UserDropDownMenu_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();

            string path = openFileDialog1.FileName;
            try
            {
                pictureBox1.Image = Image.FromFile(path);
            }
            catch
            {
                MessageBox.Show("WRONG FILE TYPE");
            }
        }

        private void MyChannelBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
        }

        private void EditVideoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
        }
    }
}

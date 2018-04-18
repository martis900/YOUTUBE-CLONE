using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace YouTUBE
{
    public partial class homeview : UserControl
    {
        public homeview()
        {
            InitializeComponent();
        }
        mainFORM prnt;
        public homeview(mainFORM pfrm)
        {
            InitializeComponent();

            prnt = pfrm;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.BackColor = Color.Gray;
            prnt.loaduploads();
        }

        public void label1_Click(object sender, EventArgs e)
        {
            label2.BackColor = Color.Red;
            prnt.loadtrends();
        }

        private void homeview_Load(object sender, EventArgs e)
        {
            
        }
    }
}

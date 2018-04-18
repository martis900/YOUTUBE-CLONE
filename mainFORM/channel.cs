using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace YouTUBE
{
    public partial class channel : UserControl
    {
        mainFORM mn;
        userData user;
        bool active;
        string id;
        public channel()
        {
            InitializeComponent();
        }
        public channel(string ids,userData us, bool active,mainFORM mn)
        {
            InitializeComponent();
            id = ids;
            this.active = active;
            user = us;
            this.mn = mn;
        }

        private void channel_Load(object sender, EventArgs e)
        {
            
            label4.Width = label3.Width;


            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            string sqltxt = string.Format("SELECT username from logins where id='{0}';",Convert.ToInt64(id));
            var reader = DBFunctions.ExecuteSqlSelect(sqltxt, connectionn);
            if (reader == null) return;
            while (reader.Read())
            {
                label3.Text = reader[0].ToString();
            }
            reader.Close();
            reader.Dispose();

            mn.loadchannel(Convert.ToInt64(id));
        }
        
    }
}

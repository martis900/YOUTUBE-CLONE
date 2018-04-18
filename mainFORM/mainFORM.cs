using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace YouTUBE
{
    public partial class mainFORM : Form
    {
        string username;
        public bool active = false;

        public userData user;
        public mainFORM()
        {
            InitializeComponent();
        }
        watchvideo prnt;

        public mainFORM(watchvideo pfrm)
        {
            InitializeComponent();

            prnt = pfrm;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            loadtrends();
            
        }

        private void like_Click(object sender, EventArgs e)
        {
           

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            signIN signin = new signIN(this);
            signin.Show();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

         public void loaduser(userData user)
        {
            this.user = user;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void homeBtn_Click(object sender, EventArgs e)
        {
                
            loadtrends();
        }
        public void loaduploads()
        {
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            if (this.Controls.ContainsKey("channel"))
            {
                this.Controls.RemoveByKey("channel");
            }

            homeview hmv = new homeview(this);

            hmv.Name = "hmw";
            hmv.label4.BackColor = Color.Red;

            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;


            int x = 10;
            int y = 10;
            int arjau = 0;

            string sqlText1 = string.Format("SELECT videos.name,videos.views,videos.ChannelID,videos.videolink,videos.uploaddate,logins.username FROM videos JOIN logins ON videos.channelid = logins.ID ORDER BY uploaddate DESC limit 16;");
            var readerr = DBFunctions.ExecuteSqlSelect(sqlText1, connectionn);
            if (readerr == null) return;

            while (readerr.Read())
            {
                //string sqlText3 = string.Format("SELECT username from logins where ID = {0};", readerr[2] );
                //  string name = (string)DBFunctions.ExecuteSqlScalar(sqlText3, connectionn);

                vid vidd = new vid();
                vidd.label1.Text = readerr[1].ToString();
                vidd.linkLabel1.Text = readerr[0].ToString() + " views";
                vidd.linkLabel2.Text = readerr[5].ToString();
                vidd.linkLabel1.Name = readerr[3].ToString();
                vidd.linkLabel2.Name = readerr[2].ToString();
                if(active == true && Convert.ToUInt64(readerr[2]) == user.user_ID)
                {
                    vidd.button1.Visible = true;
                    vidd.button1.Name = readerr[2].ToString();
                }
                else
                {
                    vidd.button1.Visible = false;
                }

                vidd.button1.Click += Button1_Click;
                vidd.linkLabel2.Click += LinkLabel2_Click;
                vidd.linkLabel1.Click += LinkLabel1_Click;

                string a = getYouTubeThumbnail(readerr[3].ToString());

                var request = WebRequest.Create(a);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    vidd.pictureBox1.Image = Bitmap.FromStream(stream);
                }

                vidd.Location = new Point(x, y);
                hmv.panel1.Controls.Add(vidd);
                arjau++;
                x += 220;

                if (arjau == 4)
                {
                    x = 10;
                    y += 200;
                    arjau = 0;
                }
            }
            hmv.Location = new Point(259, 124);
            this.Controls.Add(hmv);
            readerr.Close();
            readerr.Dispose();
            connectionn.Close();
            connectionn.Dispose();
        }

        private void LinkLabel1_Click(object sender, EventArgs e)
        {

            watchvideo wthvid = new watchvideo(this.user, ((LinkLabel)sender).Name, active, this);
            wthvid.Name = "wthvid";
            wthvid.Location = new Point(259, 124);
            this.Controls.RemoveByKey("hmw");
            this.Controls.Add(wthvid);
        }

        private void LinkLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
            channel chnl = new channel(((LinkLabel)sender).Name,  this.user,active,this);
            chnl.Name = "channel";
            chnl.Location = new Point(259, 124);
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            this.Controls.Add(chnl);

        }

        private void LinkLabel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
            channel chnl = new channel(((LinkLabel)sender).Name,this.user,active,this);
            chnl.Name = "channel";
            chnl.Location = new Point(259, 124);
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            this.Controls.Add(chnl);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            editvideo editvid = new editvideo(((Button)sender).Name);
            editvid.Show();
        }

        public void loadtrends()
        {
            
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            if (this.Controls.ContainsKey("channel"))
            {
                this.Controls.RemoveByKey("channel");
            }
            homeview hmv = new homeview(this);
            hmv.label2.BackColor = Color.Red;
            hmv.Name = "hmw";

            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            int x2 = 10;
            int y2 = 10;
            int arjau2 = 0;

            string sqlText2 = string.Format("SELECT videos.name,videos.views,videos.ChannelID,videos.videolink,videos.uploaddate,logins.username FROM videos JOIN logins ON videos.channelid = logins.ID ORDER BY views DESC limit 16;");
            var reader = DBFunctions.ExecuteSqlSelect(sqlText2, connectionn);
            if (reader == null) return;
            while (reader.Read())
            {
                vid vidd2 = new vid();

                vidd2.label1.Text = reader[1].ToString() + " views";
                vidd2.linkLabel1.Text = reader[0].ToString();
                vidd2.linkLabel2.Text = reader[5].ToString();
                vidd2.linkLabel1.Name = reader[3].ToString();

                if (active == true && Convert.ToUInt64(reader[2]) == user.user_ID)
                {
                    vidd2.button1.Visible = true;
                    vidd2.button1.Name = reader[3].ToString();
                }
                else
                {
                    vidd2.button1.Visible = false;
                }
                vidd2.linkLabel2.Name = reader[2].ToString();
                vidd2.linkLabel2.Click += LinkLabel2_Click;
                vidd2.button1.Click += Button1_Click;
                vidd2.linkLabel1.Click += LinkLabel1_Click;

                string a = getYouTubeThumbnail(reader[3].ToString());

                var request = WebRequest.Create(a);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    vidd2.pictureBox1.Image = Bitmap.FromStream(stream);
                }

                vidd2.Location = new Point(x2, y2);
                hmv.panel1.Controls.Add(vidd2);
                arjau2++;
                x2 += 220;

                if (arjau2 == 4)
                {
                    x2 = 10;
                    y2 += 200;
                    arjau2 = 0;
                }
            }
            reader.Close();
            reader.Dispose();

            hmv.Location = new Point(259, 124);
            this.Controls.Add(hmv);
            reader.Close();
            reader.Dispose();
            connectionn.Close();
            connectionn.Dispose();
        }

        

        public string getYouTubeThumbnail(string YoutubeUrl)
        {
            string youTubeThumb = string.Empty;
            if (YoutubeUrl == "")
                return "";

            if (YoutubeUrl.IndexOf("=") > 0)
            {
                youTubeThumb = YoutubeUrl.Split('=')[1];
            }
            else if (YoutubeUrl.IndexOf("/v/") > 0)
            {
                string strVideoCode = YoutubeUrl.Substring(YoutubeUrl.IndexOf("/v/") + 3);
                int ind = strVideoCode.IndexOf("?");
                youTubeThumb = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
            }
            else if (YoutubeUrl.IndexOf('/') < 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[3];
            }
            else if (YoutubeUrl.IndexOf('/') > 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[1];
            }

            return "http://img.youtube.com/vi/" + youTubeThumb + "/mqdefault.jpg";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            uploadvideo uploadvid = new uploadvideo(user);
            uploadvid.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void filllusername(long labelid,LinkLabel labelname)
        {
            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            string sqltxt = string.Format("SELECT username from logins where id='{0}';", Convert.ToInt64(labelid));
            var reader2 = DBFunctions.ExecuteSqlSelect(sqltxt, connectionn);
            if (reader2 == null) return;
            while (reader2.Read())
            {
                labelname.Text = reader2[0].ToString();
            }
            reader2.Close();
            reader2.Dispose();
        }

        private void SubscriptionsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            if (this.Controls.ContainsKey("channel"))
            {
                this.Controls.RemoveByKey("channel");
            }

            Subscriptions sbs = new Subscriptions();

            sbs.Name = "hmw";

            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            int y = 10;

            string sqlText1 = string.Format("SELECT videos.name,videos.views,videos.ChannelID,videos.videolink,videos.uploaddate,logins.username,videos.description FROM videos JOIN logins ON videos.channelid = logins.ID ORDER BY uploaddate DESC;");
            var readerr = DBFunctions.ExecuteSqlSelect(sqlText1, connectionn);
            if (readerr == null) return;

            while (readerr.Read())
            {
                //string sqlText3 = string.Format("SELECT username from logins where ID = {0};", readerr[2] );
                //  string name = (string)DBFunctions.ExecuteSqlScalar(sqlText3, connectionn);

                vid_his_sub vidsub = new vid_his_sub();

                vidsub.label1.Text = readerr[1].ToString() + " views";
                vidsub.linkLabel1.Text = readerr[0].ToString();
                vidsub.linkLabel3.Text = readerr[5].ToString();
                vidsub.linkLabel2.Text = readerr[5].ToString();
                
                vidsub.textBox3.Text = readerr[6].ToString();

                vidsub.linkLabel2.Name = readerr[2].ToString();
                vidsub.linkLabel2.Click += LinkLabel2_Click;

                vidsub.linkLabel3.Name = readerr[2].ToString();
                vidsub.linkLabel3.Click += LinkLabel3_Click;
vidsub.linkLabel1.Name = readerr[3].ToString();
                //vidsub.linkLabel1.Click += LinkLabel1_Click;
                vidsub.linkLabel1.Click += LinkLabel1_Click;

                string a = getYouTubeThumbnail(readerr[3].ToString());

                var request = WebRequest.Create(a);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    vidsub.pictureBox1.Image = Bitmap.FromStream(stream);
                }

                vidsub.Location = new Point(0, y);
                sbs.panel1.Controls.Add(vidsub);
                
                y += 200;
            }
            sbs.Location = new Point(259, 124);
                this.Controls.Add(sbs);
            readerr.Close();
            readerr.Dispose();
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            if (this.Controls.ContainsKey("channel"))
            {
                this.Controls.RemoveByKey("channel");
            }

            Subscriptions sbs = new Subscriptions();

            sbs.Name = "hmw";

            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            int y = 10;

            string sqlText1 = string.Format("SELECT videos.name,videos.views,videos.ChannelID,videos.videolink,videos.uploaddate,historyvideo.videoid FROM video JOIN historyvideo ON historyvideo.userid = {0};", user.user_ID);
            var readerr = DBFunctions.ExecuteSqlSelect(sqlText1, connectionn);
            if (readerr == null) return;

            while (readerr.Read())
            {
                //string sqlText3 = string.Format("SELECT username from logins where ID = {0};", readerr[2] );
                //  string name = (string)DBFunctions.ExecuteSqlScalar(sqlText3, connectionn);

                vid_his_sub vidsub = new vid_his_sub();

                vidsub.label1.Text = readerr[1].ToString();
                vidsub.linkLabel1.Text = readerr[0].ToString();
                vidsub.linkLabel3.Text = readerr[5].ToString();
                vidsub.linkLabel2.Text = readerr[5].ToString();
                vidsub.linkLabel1.Name = readerr[3].ToString();
                vidsub.textBox3.Text = readerr[6].ToString();

                //vidsub.linkLabel1.Click += LinkLabel1_Click;
                vidsub.linkLabel1.Click += LinkLabel1_Click;

                string a = getYouTubeThumbnail(readerr[3].ToString());

                var request = WebRequest.Create(a);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    vidsub.pictureBox1.Image = Bitmap.FromStream(stream);
                }

                vidsub.Location = new Point(0, y);
                sbs.panel1.Controls.Add(vidsub);

                y += 200;
            }
            sbs.Location = new Point(259, 124);
            this.Controls.Add(sbs);
            readerr.Close();
            readerr.Dispose();
        }

        private void mainFORM_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        private void likedBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON");
            return;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("uddm"))
            {
                this.Controls.RemoveByKey("uddm");
                return;
            }
            UserDropDownMenu uddm = new UserDropDownMenu(this);
            uddm.Name = "uddm";
            uddm.Location = new Point(1000, 64);
            this.Controls.Add(uddm);
            uddm.BringToFront();
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("hmw"))
            {
                this.Controls.RemoveByKey("hmw");
            }
            if (this.Controls.ContainsKey("wthvid"))
            {
                this.Controls.RemoveByKey("wthvid");
            }
            if (this.Controls.ContainsKey("channel"))
            {
                this.Controls.RemoveByKey("channel");
            }

            Subscriptions sbs = new Subscriptions();

            sbs.Name = "hmw";

            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            int y = 10;

            string sqlText = string.Format("SELECT videos.name,videos.views,videos.ChannelID,videos.videolink,videos.uploaddate,logins.username, videos.description FROM videos JOIN logins ON videos.channelid = logins.ID WHERE videos.name LIKE '%{0}%' ORDER BY uploaddate DESC limit 12 ;", textBox1.Text);
            var readerr = DBFunctions.ExecuteSqlSelect(sqlText, connectionn);
            if (readerr == null) return;

            while (readerr.Read())
            {
                //string sqlText3 = string.Format("SELECT username from logins where ID = {0};", readerr[2] );
                //  string name = (string)DBFunctions.ExecuteSqlScalar(sqlText3, connectionn);

                vid_his_sub vidsub = new vid_his_sub();

                vidsub.label1.Text = readerr[1].ToString() + " views";
                vidsub.linkLabel1.Text = readerr[0].ToString();
                vidsub.linkLabel3.Hide();
                vidsub.linkLabel2.Text = readerr[5].ToString();
                vidsub.linkLabel1.Name = readerr[3].ToString();
                vidsub.textBox3.Text = readerr[6].ToString();

                vidsub.linkLabel2.Name = readerr[2].ToString();
                vidsub.linkLabel1.Click += LinkLabel1_Click;
                vidsub.linkLabel2.Click += LinkLabel2_Click;

                string a = getYouTubeThumbnail(readerr[3].ToString());

                var request = WebRequest.Create(a);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    vidsub.pictureBox1.Image = Bitmap.FromStream(stream);
                }

                vidsub.Location = new Point(0, y);
                sbs.panel1.Height = this.Height - groupBox1.Height - 80;
                sbs.panel1.Controls.Add(vidsub);

                y += 200;
            }
            sbs.Location = new Point(259, 124);
            this.Controls.Add(sbs);
            readerr.Close();
            readerr.Dispose();
        }
        
        public void loadchannel(long id)
        {
            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;
            channel chl = new channel();
            int x = 10;
            int y = 10;
            int arjau = 0;
            string sqlTxt = string.Format("SELECT username from logins where id = {0}",id);
            var read = DBFunctions.ExecuteSqlSelect(sqlTxt, connectionn);
            if (read == null) return;
            while (read.Read())
            {
                username = read[0].ToString();
            }
            read.Close();
            read.Dispose();

            string sqlText1 = string.Format("SELECT videos.name,videos.views,videos.ChannelID,videos.videolink,videos.uploaddate FROM videos WHERE channelID = {0};", id );
            var readerr = DBFunctions.ExecuteSqlSelect(sqlText1, connectionn);
            if (readerr == null) return;

            while (readerr.Read())
            {
                //string sqlText3 = string.Format("SELECT username from logins where ID = {0};", readerr[2] );
                //  string name = (string)DBFunctions.ExecuteSqlScalar(sqlText3, connectionn);
                
                vid vidd = new vid();
                vidd.label1.Text = readerr[1].ToString();
                vidd.linkLabel1.Text = readerr[0].ToString() + " views";
                vidd.linkLabel2.Text = username;
                vidd.linkLabel1.Name = readerr[3].ToString();
                vidd.linkLabel2.Name = readerr[2].ToString();
                if (active == true && Convert.ToUInt64(readerr[2]) == user.user_ID)
                {
                    vidd.button1.Visible = true;
                    vidd.button1.Name = readerr[3].ToString();
                }
                else
                {
                    vidd.button1.Visible = false;
                }
                vidd.linkLabel1.Name = readerr[3].ToString();
                vidd.linkLabel1.Click += LinkLabel1_Click;

                string a = getYouTubeThumbnail(readerr[3].ToString());

                var request = WebRequest.Create(a);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    vidd.pictureBox1.Image = Bitmap.FromStream(stream);
                }

                vidd.Location = new Point(x, y);

                chl.panel1.Controls.Add(vidd);
                arjau++;
                x += 220;

                if (arjau == 4)
                {
                    x = 10;
                    y += 200;
                    arjau = 0;
                }
            }

            readerr.Close();
            readerr.Dispose();
            connectionn.Close();
            connectionn.Dispose();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = null;
        }
    }
}

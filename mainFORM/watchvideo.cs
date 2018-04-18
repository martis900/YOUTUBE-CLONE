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
    public partial class watchvideo : UserControl
    {
        ulong videoID;
        string link;
        userData user;
        bool active;
        mainFORM mainform;
        public watchvideo(userData usr, string linkas, bool actv,mainFORM mainform)
        {
            InitializeComponent();

            user = usr;
            link = linkas;
            active = actv;
            this.mainform = mainform;
        }


        private void watchvideo_Load_1(object sender, EventArgs e)
        {
            
            axShockwaveFlash1.Movie = link;

            timer1.Enabled = true;

            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;

            string sqlText = string.Format("select * from videos where videolink='{0}';", axShockwaveFlash1.Movie);
            var reader = DBFunctions.ExecuteSqlSelect(sqlText, connection);
            if (reader == null) return;

            while (reader.Read())
            {

                label9.Text = reader[1].ToString();
                label13.Text = reader[2].ToString();
                label8.Text = reader[4].ToString();
                label1.Text = reader[5].ToString();
                label2.Text = reader[6].ToString();
                label3.Text = reader[8].ToString();
                textBox3.Text = reader[7].ToString();
                videoID = (ulong)reader[0];
            }
            reader.Close();
            reader.Dispose();
            string sqltxt = string.Format("SELECT username,subscribers from logins where id='{0}';", Convert.ToInt64(label9.Text));
            var reader2 = DBFunctions.ExecuteSqlSelect(sqltxt, connection);
            if (reader2 == null) return;
            while (reader2.Read())
            {
               label9.Text = reader2[0].ToString();
               label11.Text = reader2[1].ToString();
            }
            reader2.Close();
            reader2.Dispose();
            connection.Close();
            connection.Dispose();
            coutviews();
            if(active == true)
            {
                updatelikesandviews();
                loadlikeordislike();
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!!");
            return;
        }
        private void loadlikeordislike()
        {
            string sqlText = string.Format("select count(id) from likes where videoid={0} AND userID = {1};",videoID ,user.user_ID);
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;

            var cmd = DBFunctions.ExecuteSqlScalar(sqlText, connection);
            int countuser = Convert.ToInt32(cmd);
            if(countuser == 1)
            {
                like.ForeColor = Color.Red;
                label7.Enabled = false;
            }


            sqlText = string.Format("select count(id) from dislikes where videoid={0} AND userID = {1};", videoID, user.user_ID);
             connection = DBFunctions.OpenConnection();
            if (connection == null) return;

            cmd = DBFunctions.ExecuteSqlScalar(sqlText, connection);
            countuser = Convert.ToInt32(cmd);
            if (countuser == 1)
            {
                label7.ForeColor = Color.Red;
                like.Enabled = false;
            }
            connection.Close();
            connection.Dispose();
        }

        private void countlikes()
        {
            int likes = Convert.ToInt32(label1.Text);
            int dislikes = Convert.ToInt32(label2.Text);
            progressBar1.Minimum = 0;
            progressBar1.Maximum = likes + dislikes;
            progressBar1.Value = likes;
        }

        private void coutviews()
        {
 
                string sqlText = "select views from videos where videolink='" + axShockwaveFlash1.Movie + "';";
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;
                ulong views = (ulong)DBFunctions.ExecuteSqlScalar(sqlText, connection);

                views++;
                string sqlText2 = string.Format("UPDATE videos SET views='{0}' WHERE videolink='{1}';", views, axShockwaveFlash1.Movie);

                DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
                connection.Close();
                connection.Dispose();
        }

        private void like_Click(object sender, EventArgs e)
        {
            if(active == false)
            {
                MessageBox.Show("You need to login first!");
                return;
            }
            if (like.ForeColor == Color.WhiteSmoke)
            {
                string sqlText = "select likecount from videos where videolink='" + axShockwaveFlash1.Movie + "';";
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;
                ulong likes = (ulong)DBFunctions.ExecuteSqlScalar(sqlText, connection);
                likes++;
                string sqlText2 = string.Format("UPDATE videos SET likecount='{0}' WHERE videolink='{1}';", likes, axShockwaveFlash1.Movie);

                DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
                connection.Close();
                connection.Dispose();
                like.ForeColor = Color.Red;
                label7.Enabled = false;
                connection.Close();
                connection.Dispose();
                updatelikesandviews();
                addtolikedvideos();
            }
            else if (like.ForeColor == Color.Red)
            {
                string sqlText = "select likecount from videos where videolink='" + axShockwaveFlash1.Movie + "';";
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;
                ulong likes = (ulong)DBFunctions.ExecuteSqlScalar(sqlText, connection);
                likes--;
                string sqlText2 = string.Format("UPDATE videos SET likecount='{0}' WHERE videolink='{1}';", likes, axShockwaveFlash1.Movie);

                DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
                connection.Close();
                connection.Dispose();
                like.ForeColor = Color.WhiteSmoke;
                label7.Enabled = true;
                connection.Close();
                connection.Dispose();
                updatelikesandviews();
                deletefromlikedvideos();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (active == false)
            {
                MessageBox.Show("You need to login first!");
                return;
            }
            if (label7.ForeColor == Color.WhiteSmoke)
            {
                string sqlText = "SELECT DislikeCount from videos where videolink='" + axShockwaveFlash1.Movie + "';";
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;
                ulong dislikes = (ulong)DBFunctions.ExecuteSqlScalar(sqlText, connection);
                dislikes++;
                string sqlText2 = string.Format("UPDATE videos SET dislikecount='{0}' WHERE videolink='{1}';", dislikes, axShockwaveFlash1.Movie);

                DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
                connection.Close();
                connection.Dispose();
                label7.ForeColor = Color.Red;
                like.Enabled = false;
                connection.Close();
                connection.Dispose();
                updatelikesandviews();
                addtodislikedvideos();
            }
            else if (label7.ForeColor == Color.Red)
            {
                string sqlText = "select dislikecount from videos where videolink='" + axShockwaveFlash1.Movie + "';";
                var connection = DBFunctions.OpenConnection();
                if (connection == null) return;
                ulong dislikes = (ulong)DBFunctions.ExecuteSqlScalar(sqlText, connection);
                dislikes--;
                string sqlText2 = string.Format("UPDATE videos SET dislikecount='{0}' WHERE videolink='{1}';", dislikes, axShockwaveFlash1.Movie);

                DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
                connection.Close();
                connection.Dispose();
                label7.ForeColor = Color.WhiteSmoke;
                like.Enabled = true;
                connection.Close();
                connection.Dispose();
                updatelikesandviews();
                deletefromdislikedvideos();
            }
        }
        private void updatelikesandviews()
        {
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;

            string sqlText = string.Format("select views,likecount,dislikecount from videos where videolink='{0}';", axShockwaveFlash1.Movie);
            var reader = DBFunctions.ExecuteSqlSelect(sqlText, connection);
            if (reader == null) return;

            while (reader.Read())
            {
                label8.Text = reader[0].ToString();
                label1.Text = reader[1].ToString();
                label2.Text = reader[2].ToString();
            }
            reader.Close();
            reader.Dispose();
            countlikes();
        }

        private void addtolikedvideos()
        {
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;
            string sqlText2 = string.Format("INSERT INTO likes VALUES(null, {0}, {1});",videoID,user.user_ID);
            DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
            connection.Close();
            connection.Dispose();
        }
        private void deletefromlikedvideos()
        {
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;
            string sqlText2 = string.Format("DELETE FROM likes WHERE videoID = {0} AND userID = {1};",videoID,user.user_ID);
            DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
            connection.Close();
            connection.Dispose();
        }

        private void addtodislikedvideos()
        {
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;
            string sqlText2 = string.Format("INSERT INTO dislikes VALUES(null, {0}, {1});", videoID, user.user_ID);
            DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
            connection.Close();
            connection.Dispose();
        }
        private void deletefromdislikedvideos()
        {
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;
            string sqlText2 = string.Format("DELETE FROM dislikes WHERE videoID = {0} AND userID = {1};", videoID, user.user_ID);
            DBFunctions.ExecuteSqlNoReturn(sqlText2, connection);
            connection.Close();
            connection.Dispose();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("COMING SOON!!!!");
            return;
        }
        private void senddatatohistory()
        {
            var connectionn = DBFunctions.OpenConnection();
            if (connectionn == null) return;

            string sqlText = string.Format("SELECT cout(id) FROM historyvideo WHERE videoid = {0};", videoID);
            var connection = DBFunctions.OpenConnection();
            if (connection == null) return;
            if ((ulong)DBFunctions.ExecuteSqlScalar(sqlText, connection) == 0)
            {
                sqlText = string.Format("INSERT INTO historyvideo VALUES(null, {0}, {1});", user.user_ID,videoID);
                DBFunctions.ExecuteSqlNoReturn(sqlText, connection);
                connection.Close();
                connection.Dispose();
            }
            else
            {
                sqlText = string.Format("UPDATE historyvideo SET id=null WHERE videoid='{0}';", videoID);
                DBFunctions.ExecuteSqlNoReturn(sqlText, connection);
                connection.Close();
                connection.Dispose();
            }
            
        }
    }
}

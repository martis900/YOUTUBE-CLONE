using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace YouTUBE
{
    public static class DBFunctions
    {
        private static string GetConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Port = 3306,
                UserID = "root",
                Password = "root",
                ConnectionTimeout = 30,
                Database = "youtube"

            };
            return builder.ToString();
        } // data apie connectiona
              
        public static MySqlConnection OpenConnection()
        {
            var connection = new MySqlConnection();
            try
            {
                connection.ConnectionString = GetConnectionString();
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to server:"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        } // prisijungimas
               
        public static void ExecuteSqlNoReturn(string sqlText,MySqlConnection connection)
        {
            var cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = sqlText;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong haha" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //komandos rasymas
               
        public static MySqlDataReader ExecuteSqlSelect(string SqlText,MySqlConnection connection)
        {
            var cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = SqlText;
                cmd.Connection = connection;
                return cmd.ExecuteReader();
            }
            catch (Exception exn)
            {
                MessageBox.Show("Cannot receive data from database/server" + exn, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }

        } //readina tablus ir padaro juos dvimaciais masyvais
                
        public static object ExecuteSqlScalar(string SqlText, MySqlConnection connection)
        {
            var cmd = new MySqlCommand();
            try
            {
                cmd.CommandText = SqlText;
                cmd.Connection = connection;
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot receive data from database/server:"+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }

        } //zinai kas zino kas


    }
}

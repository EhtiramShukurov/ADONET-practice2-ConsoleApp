using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Helper
{
    static class Sql
    {
        static string connectionStr = "Server=DESKTOP-VB27FQO\\MSSQLSERVER01;Database=Spotifyy;Trusted_Connection=True";
        static SqlConnection _connection;
        public static SqlConnection Connection
        {
            get {
                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionStr);
                }

                return _connection;
            }
        }
        public static void ExecuteCommand(string command)
        {
            Connection.Open();
            using (SqlCommand sc = new SqlCommand(command, Connection))
            {
                sc.ExecuteNonQuery();
            }
            Connection.Close();

        }
        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            Connection.Open();
            using (SqlDataAdapter sda = new SqlDataAdapter(query,Connection))
            {
                sda.Fill(dt);
            }
            Connection.Close();
            return dt;
        }
        }
    }

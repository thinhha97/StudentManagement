using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataConnection
    {
        public static string connectionString;
        private static string str_server;
        private static string str_database;
        private static string str_username;
        private static string str_password;

        public static void SetConnectionInfo(string server, string database, string username, string password)
        {
            str_server = server;
            str_database = database;
            str_username = username;
            str_password = password;
            SetConnectionString();
        }
        public static void SetConnectionString()
        {
            string temp = @"Server={0};Database={1};User Id={2};Password={3};";
            connectionString = String.Format(temp, str_server, str_database, str_username, str_password);
        }
        public static bool TestConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DataTable ReturnDataTable(string spName, params object[] args)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (!spName.Contains(" "))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    else
                    {
                        cmd.CommandType = CommandType.Text;
                    }
                    cmd.CommandText = spName;
                    cmd.Connection = conn;
                    if (args.Length % 2 != 0)
                    {
                        throw new Exception("Parameters must be even.");
                    }
                    if (args.Length > 0)
                    {
                        for (int i = 0; i < args.Length; i += 2)
                        {
                            SqlParameter pa = new SqlParameter(args[i].ToString(), args[i + 1]);
                            cmd.Parameters.Add(pa);
                        }
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        conn.Close();
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            if (dt == null)
                            {
                                throw new Exception("ReturnDataTable return a null table");
                            }
                            return dt;
                        }
                    }
                }
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

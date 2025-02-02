using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using Npgsql;

namespace carpark_system
{
    internal class Connectsql
    {
        public static NpgsqlConnection GetConnection()
        {
            Env.Load();
            string database = Environment.GetEnvironmentVariable("DATABASE_URL");
            NpgsqlConnection conn = new NpgsqlConnection(database);
            try
            {
                conn.Open();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("SQL Connection! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }
    }
}

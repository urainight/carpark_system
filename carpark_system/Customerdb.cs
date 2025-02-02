using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;


namespace carpark_system
{
    internal class Customerdb
    {
        public static void AddCustomer(Customers std, string querry, bool message)
        {
            NpgsqlConnection conn = Connectsql.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(@"UID", NpgsqlDbType.Varchar).Value = std.UID;
            cmd.Parameters.Add(@"Plate", NpgsqlDbType.Varchar).Value = std.Plate;
            cmd.Parameters.Add(@"Name", NpgsqlDbType.Varchar).Value = std.Name;
            cmd.Parameters.Add(@"Gender", NpgsqlDbType.Varchar).Value = std.Gender;
            cmd.Parameters.Add(@"Phone", NpgsqlDbType.Varchar).Value = std.Phone;
            cmd.Parameters.Add(@"Date_create", NpgsqlDbType.Date).Value = std.Date_create;
            cmd.Parameters.Add(@"Date_pay", NpgsqlDbType.Date).Value = std.Date_pay;
            cmd.Parameters.Add(@"Date_end", NpgsqlDbType.Date).Value = std.Date_end;
            cmd.Parameters.Add(@"Month_ticket", NpgsqlDbType.Boolean).Value = std.Month_ticket;
            cmd.Parameters.Add(@"Gate_in", NpgsqlDbType.Boolean).Value = std.Gate_in;
            try
            {
                cmd.ExecuteNonQuery();
                if (message)
                {
                    MessageBox.Show("Created Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DeleteCustomer(int customerId)
        {
            string querry = "DELETE FROM car_parking.customers WHERE id = @ID OR uid = @UID";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"ID", customerId);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void EditCustomer(Customers std, int customerId, string querry)
        {
            NpgsqlConnection conn = Connectsql.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer).Value = customerId;
            cmd.Parameters.AddWithValue("@Plate", NpgsqlDbType.Varchar).Value = std.Plate;
            cmd.Parameters.AddWithValue("@Name", NpgsqlDbType.Varchar).Value = std.Name;
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Varchar).Value = std.Gender;
            cmd.Parameters.AddWithValue("@Phone", NpgsqlDbType.Varchar).Value = std.Phone;
            cmd.Parameters.AddWithValue("@Date_pay", NpgsqlDbType.Date).Value = std.Date_pay;
            cmd.Parameters.AddWithValue("@Date_end", NpgsqlDbType.Date).Value = std.Date_end;
            cmd.Parameters.AddWithValue("@Month_ticket", NpgsqlDbType.Boolean).Value = std.Month_ticket;
            cmd.Parameters.AddWithValue("@Gate_in", NpgsqlDbType.Boolean).Value = std.Gate_in;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool CheckCustomer(string querry, string uid)
        {
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"UID", uid);
                cmd.Parameters.AddWithValue(@"Gate_in", true);
                cmd.Parameters.AddWithValue(@"Month_ticket", true);
                string UID = cmd.ExecuteScalar()?.ToString();

                if (UID != null && UID == uid)
                {
                    return true;
                }
            }
            catch (NpgsqlException)
            {
                //MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            conn.Close();
            return false;
        }

        public static void EditCustomerForGate(Customers std, string uid, string querry)
        {
            NpgsqlConnection conn = Connectsql.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UID", NpgsqlDbType.Varchar).Value = uid;
            cmd.Parameters.AddWithValue("@Plate", NpgsqlDbType.Varchar).Value = std.Plate;
            cmd.Parameters.AddWithValue("@Name", NpgsqlDbType.Varchar).Value = std.Name;
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Varchar).Value = std.Gender;
            cmd.Parameters.AddWithValue("@Phone", NpgsqlDbType.Varchar).Value = std.Phone;
            cmd.Parameters.AddWithValue("@Date_pay", NpgsqlDbType.Date).Value = std.Date_pay;
            cmd.Parameters.AddWithValue("@Date_end", NpgsqlDbType.Date).Value = std.Date_end;
            cmd.Parameters.AddWithValue("@Month_ticket", NpgsqlDbType.Boolean).Value = std.Month_ticket;
            cmd.Parameters.AddWithValue("@Gate_in", NpgsqlDbType.Boolean).Value = std.Gate_in;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteCustomerForGate(string uid)
        {
            string querry = "DELETE FROM car_parking.customers WHERE uid = @UID";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"UID", uid);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DisplayAndSearchCustomer(string querry, DataGridView dgv)
        {
            NpgsqlConnection conn = Connectsql.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            conn.Close();
        }
    }
}

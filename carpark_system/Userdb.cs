
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using NpgsqlTypes;
using Npgsql;

namespace carpark_system
{
    internal class Userdb
    {
        public static void AddUser(User std)
        {
            string querry = "INSERT INTO car_parking.users(id, username, phone, email, password, date_create, is_admin, is_login, gender) VALUES (@Id, @Username, @Phone, @Email, @Password, @Date_create, @Is_admin, @Is_login, @Gender)";
            NpgsqlConnection conn = Connectsql.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(@"Id", NpgsqlDbType.Integer).Value = std.Id;
            cmd.Parameters.Add(@"Username", NpgsqlDbType.Varchar).Value = std.Username;
            cmd.Parameters.Add(@"Phone", NpgsqlDbType.Varchar).Value = std.Phone;
            cmd.Parameters.Add(@"Email", NpgsqlDbType.Varchar).Value = std.Email;
            cmd.Parameters.Add(@"Password", NpgsqlDbType.Varchar).Value = std.Password;
            cmd.Parameters.Add(@"Date_create", NpgsqlDbType.Date).Value = std.Date_create;
            cmd.Parameters.Add(@"Is_admin", NpgsqlDbType.Boolean).Value = std.Is_admin;
            cmd.Parameters.Add(@"Is_login", NpgsqlDbType.Boolean).Value = std.Is_login;
            cmd.Parameters.Add("@Gender", NpgsqlDbType.Varchar).Value = std.Gender;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Created Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static bool CheckUser(string username, string password)
        {
            string querry = "SELECT password FROM car_parking.users WHERE username = @Username OR email = @Username";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"Username", username);
                string HashPass = cmd.ExecuteScalar()?.ToString();

                if (HashPass != null)
                {
                    if (HashandCheck.Check(password, HashPass))
                    {
                        return true;
                    }
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            conn.Close();
            return false;
        }

        public static bool CheckAdmin(string username)
        {
            string querry = "SELECT is_admin FROM car_parking.users WHERE username = @Username OR email = @Username";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try  
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"Username", username);
                bool is_admin = (bool)cmd.ExecuteScalar();
                return is_admin;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void LoginUser(string username)
        {
            string querry = "UPDATE car_parking.users SET is_login = true WHERE username = @Username OR email = @Username";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"Username", username);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static bool CheckUserLogin(string username)
        {
            string querry = "SELECT is_login FROM car_parking.users WHERE username = @Username";
            NpgsqlConnection connection = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                bool is_login = (bool)cmd.ExecuteScalar();
                return is_login;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string GetName(string username)
        {
            string querry = "SELECT username FROM car_parking.users WHERE username = @Username OR email = @Username";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"Username", username);
                string name = cmd.ExecuteScalar()?.ToString();
                return name;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void LogoutUser(string username)
        {
            string querry = "UPDATE car_parking.users SET is_login = false WHERE username = @Username OR email = @Username";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"Username", username);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DeleteUser(string username)
        {
            string querry = "DELETE FROM car_parking.users WHERE username = @Username OR email = @Username";
            NpgsqlConnection conn = Connectsql.GetConnection();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
                cmd.Parameters.AddWithValue(@"Username", username);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted User Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Error! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void EditUser(User std, string username, string querry)
        {
            NpgsqlConnection conn = Connectsql.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(querry, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", NpgsqlDbType.Integer).Value = std.Id;
            cmd.Parameters.AddWithValue("@Username", NpgsqlDbType.Varchar).Value = username;
            cmd.Parameters.AddWithValue("@Phone", NpgsqlDbType.Varchar).Value = std.Phone;
            cmd.Parameters.AddWithValue("@Email", NpgsqlDbType.Varchar).Value = std.Email;
            cmd.Parameters.AddWithValue("@Password", NpgsqlDbType.Varchar).Value = std.Password;
            cmd.Parameters.AddWithValue("@Date_edited", NpgsqlDbType.Date).Value = std.Date_updated;
            cmd.Parameters.AddWithValue("@Is_admin", NpgsqlDbType.Boolean).Value = std.Is_admin;
            cmd.Parameters.AddWithValue("@Gender", NpgsqlDbType.Varchar).Value = std.Gender;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show("Can not Updated! \n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        public static void DisplayAndSearchUser(string querry, DataGridView dgv)
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

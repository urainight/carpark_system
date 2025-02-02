using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carpark_system
{
    public partial class EmployeeForm : Form
    {
        RegisterForm Form;
        private string username;
        public EmployeeForm(string username)
        {
            InitializeComponent();
            Form = new RegisterForm(this);
            this.username = Userdb.GetName(username);
            namelb.Text = $"Welcome {this.username}";
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Userdb.LogoutUser(this.username);
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void addemployeebtn_Click(object sender, EventArgs e)
        {
            Form = new RegisterForm(this);
            Form.Clear();
            Form.ShowDialog();
        }

        public void Display()
        {
            string querry_admin = "SELECT id, username, phone, email, gender, date_create, date_edited, is_admin FROM car_parking.users WHERE is_admin = true AND username NOT LIKE '%" + this.username + "%'";
            Userdb.DisplayAndSearchUser(querry_admin, Admingridview);
            string querry_employee = "SELECT id, username, phone, email, gender, date_create, date_edited, is_admin FROM car_parking.users WHERE is_admin = false";
            Userdb.DisplayAndSearchUser(querry_employee, Employeegridview);
        }

        private void EmployeeForm_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void findAdmintxt_TextChanged(object sender, EventArgs e)
        {
            string querry = "SELECT id, username, phone, email, gender, date_create, date_edited, is_admin FROM car_parking.users WHERE username LIKE '%" + findAdmintxt.Text + "%' AND username NOT LIKE '%" + this.username +"%' AND is_admin = true";
            Userdb.DisplayAndSearchUser(querry, Admingridview);
        }

        private void Admingridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this product", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string username = Admingridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Userdb.DeleteUser(username);
                    Display();
                }
                return;
            }
            if (e.ColumnIndex == 0)
            {
                Form.Clear();
                Form.admin = (bool)Admingridview.Rows[e.RowIndex].Cells[9].Value;
                Form.id = Admingridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                Form.username = Admingridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                Form.phone = Admingridview.Rows[e.RowIndex].Cells[4].Value.ToString();
                Form.email = Admingridview.Rows[e.RowIndex].Cells[5].Value.ToString();
                Form.gender = Admingridview.Rows[e.RowIndex].Cells[6].Value.ToString();
                Form.UpdateInfo();
                Form.ShowDialog();
                return;
            }
        }

        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            var workForm = new WorkForm(this.username);
            this.Hide();
            workForm.ShowDialog();
            this.Close();
        }

        private void findEmployeetxt_TextChanged(object sender, EventArgs e)
        {
            string querry = "SELECT id, username, phone, email, gender, date_create, date_edited, is_admin FROM car_parking.users WHERE username LIKE '%" + findEmployeetxt.Text + "%' AND username NOT LIKE '%" + this.username + "%' AND is_admin = false";
            Userdb.DisplayAndSearchUser(querry, Employeegridview);
        }

        private void Employeegridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this product", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string username = Employeegridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Userdb.DeleteUser(username);
                    Display();
                }
                return;
            }
            if (e.ColumnIndex == 0)
            {
                Form.Clear();
                Form.admin = (bool)Employeegridview.Rows[e.RowIndex].Cells[9].Value;
                Form.id = Employeegridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                Form.username = Employeegridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                Form.phone = Employeegridview.Rows[e.RowIndex].Cells[4].Value.ToString();
                Form.email = Employeegridview.Rows[e.RowIndex].Cells[5].Value.ToString();
                Form.gender = Employeegridview.Rows[e.RowIndex].Cells[6].Value.ToString();
                Form.UpdateInfo();
                Form.ShowDialog();
                return;
            }
        }

        private void customerbtn_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm(this.username);
            this.Hide();
            customerForm.ShowDialog();
            this.Close();
        }
    }
}

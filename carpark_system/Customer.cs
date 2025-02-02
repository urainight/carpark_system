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
    public partial class CustomerForm : Form
    {
        AddCustomerForm Form;
        private string username;
        public CustomerForm(string username)
        {
            InitializeComponent();
            this.username = username;
            namelb.Text = $"Welcome {this.username}";
            Form = new AddCustomerForm(this);
        }

        private void dashboardbtn_Click(object sender, EventArgs e)
        {
            var dashboardForm = new WorkForm(this.username);
            this.Hide();
            dashboardForm.ShowDialog();
            this.Close();
        }

        private void employeebtn_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm(this.username);
            this.Hide();
            employeeForm.ShowDialog();
            this.Close();
        }

        private void CustomerForm_Shown(object sender, EventArgs e)
        {
            bool admin = Userdb.CheckAdmin(this.username);
            if (!admin)
            {
                employeebtn.Visible = false;
            }
            DisplayCustomer();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Userdb.LogoutUser(this.username);
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void addCustomerbtn_Click(object sender, EventArgs e)
        {
            Form = new AddCustomerForm(this);
            Form.Clear();
            Form.ShowDialog();
        }

        public void DisplayCustomer()
        {
            string querry = "SELECT id, license_plate, username, gender, phone, date_created, date_paycheck, date_end, month_ticket FROM car_parking.customers WHERE month_ticket = true";
            Customerdb.DisplayAndSearchCustomer(querry, Customergridview);
        }

        private void Customergridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                Form.Clear();
                Form.id = Customergridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                Form.plate = Customergridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                Form.username = Customergridview.Rows[e.RowIndex].Cells[4].Value.ToString();
                Form.gender = Customergridview.Rows[e.RowIndex].Cells[5].Value.ToString();
                Form.phone = Customergridview.Rows[e.RowIndex].Cells[6].Value.ToString();
                Form.date_pay = Convert.ToDateTime(Customergridview.Rows[e.RowIndex].Cells[7].Value);
                Form.UpdateCustomer();
                Form.ShowDialog();
                return;
            }

            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this product", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = Customergridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Customerdb.DeleteCustomer(int.Parse(id));
                    DisplayCustomer();
                }
                return;
            }
        }

        private void findCustomertxt_TextChanged(object sender, EventArgs e)
        {
            string querry = "SELECT id, license_plate, username, gender, phone, date_created, date_paycheck, date_end, month_ticket FROM car_parking.customers WHERE username LIKE '%" + findCustomertxt.Text + "%' AND month_ticket = true";
            Userdb.DisplayAndSearchUser(querry, Customergridview);
        }
    }
}

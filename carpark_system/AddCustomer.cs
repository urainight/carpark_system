using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace carpark_system
{
    public partial class AddCustomerForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly CustomerForm _parent;
        public string id, plate, username, gender, phone;
        public DateTime date_pay;

        private StringBuilder dataBuffer = new StringBuilder();

        public AddCustomerForm(CustomerForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateCustomer()
        {
            label1.Text = "Update Customer";
            addbtn.Text = "Update";
            licenseplatetxt.Text = plate;
            usernametxt.Text = username;
            gendercb.Text = gender;
            phonetxt.Text = phone;
            datepaycheckpicker.Value = date_pay;
            connectbtn.Visible = false;
            scanbtn.Visible = false;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            AddCustomerForm.ActiveForm.Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void uidtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                licenseplatetxt.Focus();
            }
        }

        private void licenseplatetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                usernametxt.Focus();
            }
        }

        private void usernametxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gendercb.Focus();
            }
        }

        private void gendercb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phonetxt.Focus();
            }
        }

        private void phonetxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                datepaycheckpicker.Focus();
            }
        }

        private void datepaycheckpicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addbtn.PerformClick();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AddCustomerForm_Shown(object sender, EventArgs e)
        {
            uidtxt.Focus();
        }

        public void Clear()
        {
            uidtxt.Text = licenseplatetxt.Text = usernametxt.Text = gendercb.Text = phonetxt.Text = "";
            datepaycheckpicker.Value = DateTime.Now;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (addbtn.Text == "Add")
            {
                if (uidtxt.Text == "" || usernametxt.Text == "" || gendercb.Text == "" || phonetxt.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string querry = "INSERT INTO car_parking.customers (uid, license_plate, username, gender, phone, date_created, date_paycheck, date_end, month_ticket, gate_in) VALUES (@UID, @Plate, @Name, @Gender, @Phone, @Date_create, @Date_pay, @Date_end, @Month_ticket, @Gate_in)";
                    Customers std = new Customers(uidtxt.Text, licenseplatetxt.Text, usernametxt.Text, gendercb.Text, phonetxt.Text, datepaycheckpicker.Value, true, false);
                    Customerdb.AddCustomer(std, querry, true);
                    Clear();
                }
            }

            if (addbtn.Text == "Update")
            {
                if (usernametxt.Text == "" || gendercb.Text == "" || phonetxt.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Customers std = new Customers(uidtxt.Text, licenseplatetxt.Text, usernametxt.Text, gendercb.Text, phonetxt.Text, datepaycheckpicker.Value, true, false);
                    string querry = "UPDATE car_parking.customers SET license_plate = @Plate, username = @Name, gender = @Gender, phone = @Phone, date_paycheck = @Date_pay, date_end = @Date_end WHERE id = @Id";
                    Customerdb.EditCustomer(std, int.Parse(id), querry);
                    Clear();
                }
            }
            _parent.DisplayCustomer();
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            var ConnectSerialForm = new ConnectComForm();
            ConnectSerialForm.ShowDialog();
        }

        private void scanbtn_Click(object sender, EventArgs e)
        {
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            try
            {
                if (!serialPort.IsOpen)
                {
                    MessageBox.Show("Please connect to the port first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SerialPortManager.Instance.SendData("scan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCustomerForm_Load(object sender, EventArgs e)
        {
            SerialPortManager.Instance.DataReceived += SerialPort_DataReceivedHandler;
        }

        private void AddCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialPortManager.Instance.DataReceived -= SerialPort_DataReceivedHandler;
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void SerialPort_DataReceivedHandler(object sender, string data)
        {
            dataBuffer.Append(data);
            Invoke(new Action(() =>
            {
                String completedata = dataBuffer.ToString();

                if (completedata.Contains("\n"))
                {
                    string[] dataArr = completedata.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String item in dataArr)
                    {
                        if (item.StartsWith("UID: "))
                        {
                            uidtxt.Text = item.Substring(5);
                        }
                    }
                    dataBuffer.Clear();
                }
            }));
        }
    }
}

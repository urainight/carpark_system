using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace carpark_system
{
    public partial class RegisterForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private readonly EmployeeForm _parent;
        public string id, username, phone, gender, email;
        public bool admin;

        public RegisterForm(EmployeeForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            RegisterForm.ActiveForm.Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void idtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nametxt.Focus();
            }
        }

        private void nametxt_KeyDown(object sender, KeyEventArgs e)
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
                gendercbtxt.Focus();
            }
        }

        private void gendercbtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailtxt.Focus();
            }
        }

        private void emailtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                passwordtxt.Focus();
            }
        }

        private void passwordtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Signupbtn.PerformClick();
            }
        }

        private void showbtn_Click(object sender, EventArgs e)
        {
            if (passwordtxt.PasswordChar == '\0')
            {
                hidebtn.BringToFront();
                passwordtxt.PasswordChar = '*';
            }
        }

        private void hidebtn_Click(object sender, EventArgs e)
        {
            if (passwordtxt.PasswordChar == '*')
            {
                showbtn.BringToFront();
                passwordtxt.PasswordChar = '\0';
            }
        }

        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            idtxt.Focus();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void UpdateInfo()
        {
            label1.Text = "Update Employee";
            Signupbtn.Text = "Update";
            admincheckbox.Checked = admin;
            idtxt.Text = id;
            nametxt.Text = username;
            phonetxt.Text = phone;
            emailtxt.Text = email;
            gendercbtxt.Text = gender;
        }

        public void Clear()
        {
            idtxt.Text = nametxt.Text = phonetxt.Text = emailtxt.Text = passwordtxt.Text = gendercbtxt.Text = "";
            admincheckbox.Checked = false;
        }

        private void Signupbtn_Click(object sender, EventArgs e)
        {
            if (Signupbtn.Text == "Add")
            {
                if (idtxt.Text == "" || nametxt.Text == "" || phonetxt.Text == "" || gendercbtxt.Text == "" || emailtxt.Text == "" || passwordtxt.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool success = int.TryParse(idtxt.Text, out int id);
                    if (!success)
                    {
                        MessageBox.Show("Please enter a valid id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    User std = new User(int.Parse(idtxt.Text), nametxt.Text, phonetxt.Text, emailtxt.Text, passwordtxt.Text, gendercbtxt.SelectedItem.ToString(), admincheckbox.Checked);
                    Userdb.AddUser(std);
                    Clear();
                }
            }
            if (Signupbtn.Text == "Update")
            {
                if (idtxt.Text == "" || nametxt.Text == "" || phonetxt.Text == "" || gendercbtxt.Text == "" || emailtxt.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool success = int.TryParse(idtxt.Text, out int id);
                    if (!success)
                    {
                        MessageBox.Show("Please enter a valid id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    User std = new User(int.Parse(idtxt.Text), nametxt.Text, phonetxt.Text, emailtxt.Text, passwordtxt.Text, gendercbtxt.SelectedItem.ToString(), admincheckbox.Checked);
                    if (passwordtxt.Text == "")
                    {
                        string querry = "UPDATE car_parking.users SET id = @Id, username = @Username, phone = @Phone, email = @Email, date_edited = @Date_edited, is_admin = @Is_admin, gender = @Gender WHERE username = @Username";
                        Userdb.EditUser(std, nametxt.Text, querry);
                    }
                    else
                    {
                        string querry = "UPDATE car_parking.users SET id = @Id, username = @Username, phone = @Phone, email = @Email, password = @Password, date_edited = @Date_edited, is_admin = @Is_admin, gender = @Gender WHERE username = @Username";
                        Userdb.EditUser(std, nametxt.Text, querry);
                    }
                    Clear();
                }
            }
            _parent.Display();
        }
    }
}

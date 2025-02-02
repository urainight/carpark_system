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
    public partial class LoginForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            if(passwordtxt.PasswordChar == '*')
            {
                showbtn.BringToFront();
                passwordtxt.PasswordChar = '\0';
            }
        }

        private void usernametxt_KeyDown(object sender, KeyEventArgs e)
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
                loginbtn.PerformClick();
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            usernametxt.Focus();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            bool authenticate = Userdb.CheckUser(usernametxt.Text, passwordtxt.Text);
            if (authenticate)
            {
                Userdb.LoginUser(usernametxt.Text);
                var work_form = new WorkForm(usernametxt.Text);
                this.Hide();
                work_form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

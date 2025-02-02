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
    public partial class ConnectComForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public ConnectComForm()
        {
            InitializeComponent();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            ConnectComForm.ActiveForm.Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ConnectComForm_Shown(object sender, EventArgs e)
        {
            baudratecb.Text = baudratecb.Items[0].ToString();
            var serialPort1 = SerialPortManager.Instance.GetSerialPort();
            
            connectbtn.Enabled = !serialPort1.IsOpen;
            disconnectbtn.Enabled = serialPort1.IsOpen;
        }

        private void portcb_DropDown(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portcb.Items.Clear();
            portcb.Items.AddRange(ports);
        }

        private void connectbtn_Click(object sender, EventArgs e)
        {
            try
            {
                string PortName = portcb.Text;
                int BaudRate = Convert.ToInt32(baudratecb.Text);

                SerialPortManager.Instance.ConfigurePort(PortName, BaudRate);
                var serialPort = SerialPortManager.Instance.GetSerialPort();

                serialPort.Open();

                connectbtn.Enabled = false;
                disconnectbtn.Enabled = true;

                if(serialPort.IsOpen)
                {
                    MessageBox.Show("Port is connected", "Com Port", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectbtn_Click(object sender, EventArgs e)
        {
            try
            {
                var serialPort = SerialPortManager.Instance.GetSerialPort();
                serialPort.Close();

                connectbtn.Enabled = true;
                disconnectbtn.Enabled = false;

                if (!serialPort.IsOpen)
                {
                    MessageBox.Show("Port is disconnected", "Com Port", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

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
    public partial class ManualForm : Form
    {
        public const int MOVE_NCLBUTTONDOWN = 0xA1;
        public const int MOVE_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private StringBuilder sb = new StringBuilder();
        public ManualForm()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, MOVE_NCLBUTTONDOWN, MOVE_CAPTION, 0);
            }
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ManualForm_Load(object sender, EventArgs e)
        {
            SerialPortManager.Instance.DataReceived += SerialPortManager_DataReceived;
        }

        private void ManualForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialPortManager.Instance.DataReceived -= SerialPortManager_DataReceived;
        }

        private void SerialPortManager_DataReceived(object sender, string data)
        {
            sb.Append(data);
            Invoke(new Action(() =>
            {
                string completedata = sb.ToString();

                if (completedata.Contains("\n"))
                {
                    string[] dataArr = completedata.Split(new [] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String item in dataArr)
                    {
                        if (item.StartsWith("GateIn:"))
                        {
                            GateInState(item.Substring(7).Trim());
                        }
                        if (item.StartsWith("GateOut:"))
                        {
                            GateOutState(item.Substring(8).Trim());
                        }
                    }
                    sb.Clear();
                }
            }));
        }

        private void GateInState(string data)
        {
            if (data == "open")
            {
                GateinopenLedon.BringToFront();
                GateinopenLedoff.SendToBack();
                GateincloseLedon.SendToBack();
                GateincloseLedoff.BringToFront();
                openGateinbtn.Enabled = false;
                closeGateinbtn.Enabled = true;
            }
            else
            {
                GateinopenLedon.SendToBack();
                GateinopenLedoff.BringToFront();
                GateincloseLedon.BringToFront();
                GateincloseLedoff.SendToBack();
                openGateinbtn.Enabled = true;
                closeGateinbtn.Enabled = false;
            }
        }

        private void GateOutState(string data)
        {
            if (data == "open")
            {
                GateoutopenLedon.BringToFront();
                GateoutopenLedoff.SendToBack();
                GateoutcloseLedon.SendToBack();
                GateoutcloseLedoff.BringToFront();
                openGateoutbtn.Enabled = false;
                closeGateoutbtn.Enabled = true;
            }
            else
            {
                GateoutopenLedon.SendToBack();
                GateoutopenLedoff.BringToFront();
                GateoutcloseLedon.BringToFront();
                GateoutcloseLedoff.SendToBack();
                openGateoutbtn.Enabled = true;
                closeGateoutbtn.Enabled = false;
            }
        }

        private void openGateinbtn_Click(object sender, EventArgs e)
        {
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            if (serialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("OpenGateIn");
            }
        }

        private void closeGateinbtn_Click(object sender, EventArgs e)
        {
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            if (serialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("CloseGateIn");
            }
        }

        private void openGateoutbtn_Click(object sender, EventArgs e)
        {
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            if (serialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("OpenGateOut");
            }
        } 

        private void closeGateoutbtn_Click(object sender, EventArgs e)
        {
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            if (serialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("CloseGateOut");
            }
        }
    }
}

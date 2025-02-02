using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace carpark_system
{
    internal class SerialPortManager
    {
        private static SerialPortManager instance;
        private SerialPort serialPort;

        public event EventHandler<string> DataReceived;

        private SerialPortManager()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += SerialPort_DataReceived;
        }

        public static SerialPortManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialPortManager();
                }
                return instance;
            }
        }

        public SerialPort GetSerialPort()
        {
            return serialPort;
        }

        public void ConfigurePort(string portName, int baudRate)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadExisting();
                DataReceived?.Invoke(this, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendData(string data)
        {
            try
            {
                serialPort.Write(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Tesseract;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace carpark_system
{
    public partial class WorkForm : Form
    {
        private string username;
        private bool CancelClick = false;
        private StringBuilder sb = new StringBuilder();
        private bool Is_auto;

        private VideoCaptureDevice videoSource;
        List<Image<Bgr, byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        Image Plate_Draw;
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();
        PictureBox[] box = new PictureBox[12];

        public TesseractEngine full_tesseract = null;
        public TesseractEngine ch_tesseract = null;
        public TesseractEngine num_tesseract = null;
        private string m_path = Application.StartupPath + @"\tessdata\";
        private List<string> lstimages = new List<string>();
        private const string m_lang = "eng";

        ManualForm Form;
        public WorkForm(string username)
        {
            InitializeComponent();
            this.username = Userdb.GetName(username);
            namelb.Text = $"Welcome {this.username}";
            LoadCamera();
        }

        public void Clear()
        {
            platetxt.Text = uidtxt.Text = "";
        }

        public void Display()
        {
            string querry = "SELECT id, license_plate, username, month_ticket FROM car_parking.customers WHERE gate_in = true";
            Customerdb.DisplayAndSearchCustomer(querry, informdataGridview);
        }

        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Username = this.username;
            Properties.Settings.Default.Save();
            var SerialPort = SerialPortManager.Instance.GetSerialPort();
            if (SerialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("end");
                SerialPort.Close();
            }
            SerialPortManager.Instance.DataReceived -= SerialPort_DataReceivedHandler;
            if (videoSource != null && videoSource.IsRunning) 
            {
                videoSource.Stop();
                videoSource = null;
            }
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            SerialPortManager.Instance.DataReceived += SerialPort_DataReceivedHandler;
            Cameraoffbtn.Enabled = false;
            try
            {
                full_tesseract = new TesseractEngine(m_path, m_lang, EngineMode.Default);
                ch_tesseract = new TesseractEngine(m_path, m_lang, EngineMode.Default);
                num_tesseract = new TesseractEngine(m_path, m_lang, EngineMode.Default);

                full_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890").ToString();
                ch_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ").ToString();
                num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890").ToString();

                m_path = Environment.CurrentDirectory + "\\";
                for (int i = 0; i < box.Length; i++)
                {
                    box[i] = new PictureBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WorkForm_Shown(object sender, EventArgs e)
        {
            Display();
            bool admin = Userdb.CheckAdmin(this.username);
            if (!admin)
            {
                employeebtn.Visible = false;
            }
        }

        private void SerialPort_DataReceivedHandler(object sender, string data)
        {
            sb.Append(data);
            Invoke(new Action(() =>
            {
                String completedata = sb.ToString();

                if (completedata.Contains("\n"))
                {
                    string[] dataArr = completedata.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String item in dataArr)
                    {
                        if (item.StartsWith("UID:"))
                        {
                            uidtxt_Update(item.Substring(5));
                        }
                        if (item.StartsWith("GateIn:"))
                        {
                            GateInState(item.Substring(7).Trim());
                        }
                        if (item.StartsWith("GateOut:"))
                        {
                            GateOutState(item.Substring(8).Trim());
                        }
                        if (item.StartsWith("Count:"))
                        {
                            NumberParktxt.Text = item.Substring(6);
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
                OpenGateinLedon.BringToFront();
                OpenGateinLedoff.SendToBack();
                CloseGateinLedoff.BringToFront();
                CloseGateinLedon.SendToBack();
            }
            else
            {
                OpenGateinLedon.SendToBack();
                OpenGateinLedoff.BringToFront();
                CloseGateinLedoff.SendToBack();
                CloseGateinLedon.BringToFront();
            }
        }

        private void GateOutState(string data)
        {
            if (data == "open")
            {
                OpenGateoutLedon.BringToFront();
                OpenGateoutLedoff.SendToBack();
                CloseGateoutLedoff.BringToFront();
                CloseGateoutLedon.SendToBack();
            }
            else
            {
                OpenGateoutLedon.SendToBack();
                OpenGateoutLedoff.BringToFront();
                CloseGateoutLedoff.SendToBack();
                CloseGateoutLedon.BringToFront();
            }
        }

        private void TextBoxes_TextChanges()
        {
            if (!String.IsNullOrEmpty(uidtxt.Text) && !String.IsNullOrEmpty(platetxt.Text) && Is_auto)
            {
                CancelClick = true;
                addbtn.PerformClick();
                CancelClick = false;
            }
        }

        private void platetxt_Update(string data)
        {
            platetxt.Text = data;
            TextBoxes_TextChanges();
        }

        private void uidtxt_Update(string data)
        {
            uidtxt.Text = data;
            TextBoxes_TextChanges();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            Userdb.LogoutUser(this.username);
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void employeebtn_Click(object sender, EventArgs e)
        {
            var employeeForm = new EmployeeForm(this.username);
            this.Hide();
            employeeForm.ShowDialog();
            this.Close();
        }

        private void customerbtn_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm(this.username);
            this.Hide();
            customerForm.ShowDialog();
            this.Close();
        }

        private void serialbtn_Click(object sender, EventArgs e)
        {
            var serialForm = new ConnectComForm();
            serialForm.ShowDialog();
        }

        private void manualbtn_Click(object sender, EventArgs e)
        {
            var SerialPort = SerialPortManager.Instance.GetSerialPort();
            if (SerialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("manual");
                manualLedon.BringToFront();
                manualLedoff.SendToBack();
                autoLedon.SendToBack();
                autoLedoff.BringToFront();

                manualbtn.Enabled = false;
                autobtn.Enabled = true;
                CancelClick = true;
                Is_auto = false;

                Clear();

                Form = new ManualForm();
                Form.Show();
            }
            else
            {
                MessageBox.Show("Please connect to the port first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void autobtn_Click(object sender, EventArgs e)
        {
            var SerialPort = SerialPortManager.Instance.GetSerialPort();
            if (SerialPort.IsOpen)
            {
                SerialPortManager.Instance.SendData("auto");
                autoLedon.BringToFront();
                autoLedoff.SendToBack();
                manualLedon.SendToBack();
                manualLedoff.BringToFront();

                autobtn.Enabled = false;
                manualbtn.Enabled = true;
                CancelClick = false;
                Is_auto = true;

                Clear();

                if (Form != null)
                {
                    Form.Close();
                }
            }
            else
            {
                MessageBox.Show("Please connect to the port first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            var serialPort = SerialPortManager.Instance.GetSerialPort();
            if (CancelClick)
            {
                if (String.IsNullOrEmpty(platetxt.Text) || String.IsNullOrEmpty(uidtxt.Text))
                {
                    MessageBox.Show("Please scan the UID card and License Plate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string querry = "SELECT uid FROM car_parking.customers WHERE uid = @UID";
                    bool check = Customerdb.CheckCustomer(querry, uidtxt.Text);
                    if (check) 
                    {
                        string querry2 = "SELECT uid FROM car_parking.customers WHERE uid = @UID AND gate_in = @Gate_in";
                        bool check2 = Customerdb.CheckCustomer(querry2, uidtxt.Text);

                        if (check2)
                        {
                            string querry3 = "SELECT uid FROM car_parking.customers WHERE uid = @UID AND gate_in = @Gate_in AND month_ticket = @Month_ticket";
                            bool check3 = Customerdb.CheckCustomer(querry3, uidtxt.Text);
                            
                            if (check3)
                            {
                                Customers std = new Customers(uidtxt.Text, platetxt.Text, string.Empty, string.Empty, string.Empty, DateTime.Now, true, false);
                                string querry_update2 = "UPDATE car_parking.customers SET gate_in = @Gate_in WHERE uid = @UID AND month_ticket = true";
                                Customerdb.EditCustomerForGate(std, uidtxt.Text, querry_update2);
                                //opengateout
                                if (serialPort.IsOpen && Is_auto)
                                {
                                    SerialPortManager.Instance.SendData("out");
                                }
                            }
                            else
                            {
                                Customerdb.DeleteCustomerForGate(uidtxt.Text);
                                //opengateout
                                if (serialPort.IsOpen && Is_auto)
                                {
                                    SerialPortManager.Instance.SendData("out");
                                }
                            }
                        }
                        else
                        {
                            Customers std = new Customers(uidtxt.Text, platetxt.Text, string.Empty, string.Empty, string.Empty, DateTime.Now, true, true);
                            string querry_update = "UPDATE car_parking.customers SET gate_in = @Gate_in WHERE uid = @UID";
                            Customerdb.EditCustomerForGate(std, uidtxt.Text, querry_update);
                            //opengatein
                            if (serialPort.IsOpen && Is_auto)
                            {
                                SerialPortManager.Instance.SendData("in");
                            }
                        }
                    }
                    else
                    {
                        Customers std = new Customers(uidtxt.Text, platetxt.Text, string.Empty, string.Empty, string.Empty, DateTime.Now, false, true);
                        querry = "INSERT INTO car_parking.customers (uid, license_plate, gate_in) VALUES (@UID, @Plate, @Gate_in)";
                        Customerdb.AddCustomer(std, querry, false);
                        //opengatein
                        if (serialPort.IsOpen && Is_auto)
                        {
                            SerialPortManager.Instance.SendData("in");
                        }
                    }
                }
            }
            Clear();
            Display();
        }

        private void LoadCamera()
        {
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                cameraBox.Items.Add(device.Name);
            }
            cameraBox.SelectedIndex = 0;
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox2.Image = bitmap;
        }

        private VideoCapabilities SelectResolution(VideoCaptureDevice videoSource, int width, int height)
        {
            VideoCapabilities[] allResolutions = videoSource.VideoCapabilities;
            VideoCapabilities selectedResolution = null;
            foreach (VideoCapabilities cap in allResolutions)
            {
                if (cap.FrameSize.Width == width && cap.FrameSize.Height == height)
                {
                    selectedResolution = cap;
                    break;
                }
            }
            return selectedResolution;
        }

        private void Cameraonbtn_Click(object sender, EventArgs e)
        {
            if (cameraBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a camera");
                return;
            }
            var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[cameraBox.SelectedIndex].MonikerString);
            videoSource.VideoResolution = SelectResolution(videoSource, 640, 480);
            videoSource.NewFrame += VideoSource_NewFrame;
            videoSource.Start();
            Cameraonbtn.Enabled = false;
            Cameraoffbtn.Enabled = true;
        }

        private void Cameraoffbtn_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource = null;
            }
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            Cameraonbtn.Enabled = true;
            Cameraoffbtn.Enabled = false;
        }

        private void Capturebtn_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                Bitmap bitmap = (Bitmap)pictureBox2.Image.Clone();
                bitmap.Save("aa.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                FileStream fs = new FileStream(m_path + "aa.bmp", FileMode.Open, FileAccess.Read);
                Image temp = Image.FromStream(fs);
                fs.Close();
                pictureBox3.Image = temp;
                pictureBox3.Update();
                Image temp1;
                string temp2, temp3;
                Reconize(m_path + "aa.bmp", out temp1, out temp2, out temp3);
                pictureBox2.Image = temp1;
                if (temp3 == "")
                {
                    platetxt.Text = "No license plate found";
                }
                else
                {
                    platetxt.Text = temp3;
                }
            }
        }

        private void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            FileStream fs = new FileStream(urlImage, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            Bitmap bitmap = new Bitmap(img);
            fs.Close();

            FindLicensePlate(bitmap, out Plate_Draw);
        }

        private static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform(offset.X, offset.Y);
                g.RotateTransform(angle);
                g.TranslateTransform(-offset.X, -offset.Y);
                g.DrawImage(image, new PointF(0, 0));
            }
            return rotatedImage;
        }

        private void FindLicensePlate(Bitmap image, out Image PlateDraw)
        {
            PlateDraw = null;
            Image<Bgr, byte> frame;
            bool isFace = false;
            Bitmap src;
            Image dst = image;
            CascadeClassifier cascade = new CascadeClassifier(Application.StartupPath + "\\output-hv-33-x25.xml");

            for (float i = 0; i <= 20; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    PlateImagesList.Clear();
                    frame = new Image<Bgr, byte>(src.ToImage<Bgr, byte>().Data);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src.ToImage<Gray, byte>().Data))
                    {
                        var faces = cascade.DetectMultiScale(grayframe, 1.1, 15, new Size(10, 10), new Size(500, 500));

                        foreach (var face in faces)
                        {
                            Image<Bgr, byte> tmp = frame.Copy();
                            tmp.ROI = face;

                            frame.Draw(face, new Bgr(Color.Blue), 2);

                            PlateImagesList.Add(tmp);

                            isFace = true;
                        }
                        if (isFace)
                        {
                            Image<Bgr, byte> showimg = frame.Clone();
                            PlateDraw = (Image)showimg.ToBitmap();
                            if (PlateImagesList.Count > 1)
                            {
                                for (int k = 1; k < PlateImagesList.Count; k++)
                                {
                                    if (PlateImagesList[0].Width < PlateImagesList[k].Width)
                                    {
                                        PlateImagesList[0] = PlateImagesList[k];
                                    }
                                }
                            }
                            PlateImagesList[0] = PlateImagesList[0].Resize(400, 400, Inter.Linear);
                            return;
                        }
                    }
                }
            }
        }

        private string Ocr(Bitmap image_s, bool isFull, bool isNum = false)
        {
            string temp = "";
            Image<Gray, byte> src = new Image<Gray, byte>(image_s.ToImage<Gray, byte>().Data);
            CvInvoke.Threshold(src, src, 128, 255, ThresholdType.Binary);
            CvInvoke.GaussianBlur(src, src, new Size(3, 3), 0);
            double ratio = 1;
            while (true)
            {
                ratio = (double)CvInvoke.CountNonZero(src) / (src.Width * src.Height);
                if (ratio > 0.5) break;
                src = src.Dilate(2);
            }
            Bitmap image = src.ToBitmap();

            TesseractEngine ocr;
            if (isFull)
                ocr = full_tesseract;
            else if (isNum)
                ocr = num_tesseract;
            else
                ocr = ch_tesseract;

            int cou = 0;
            //ocr.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
            ocr.DefaultPageSegMode = PageSegMode.SingleBlock;
            ocr.SetVariable("tessedit_reset_classifier", "1");
            using (var pages = ocr.Process(image))
            {
                temp = pages.GetText();
            }
            while (temp.Length > 3)
            {
                Image<Gray, byte> temp2 = new Image<Gray, byte>(image.ToImage<Gray, byte>().Data);
                temp2 = temp2.Erode(2);
                image = temp2.ToBitmap();
                ocr.SetVariable("tessedit_reset_classifier", "1");
                using (var pages = ocr.Process(image))
                {
                    temp = pages.GetText();
                }
                cou++;
                if (cou > 10)
                {
                    temp = "";
                    break;
                }
            }
            return temp;
        }

        private void Reconize(string link, out Image hinhbienso, out string bienso, out string bienso_text)
        {
            for (int i = 0; i < box.Length; i++)
            {
                this.Controls.Remove(box[i]);
            }

            hinhbienso = null;
            bienso = "";
            bienso_text = "";
            ProcessImage(link);
            if (PlateImagesList.Count != 0)
            {
                Bitmap imgBit = PlateImagesList[0].ToBitmap();
                Image<Bgr, byte> src = new Image<Bgr, byte>(imgBit.ToImage<Bgr, byte>().Data);
                Bitmap grayframe;
                FindContours con = new FindContours();
                Bitmap color;
                int c = con.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);


                hinhbienso = Plate_Draw;


                Image<Gray, byte> dst = new Image<Gray, byte>(grayframe.ToImage<Gray, byte>().Data);

                grayframe = dst.ToBitmap();

                string zz = "";


                List<Bitmap> bmp = new List<Bitmap>();
                List<int> erode = new List<int>();
                List<Rectangle> up = new List<Rectangle>();
                List<Rectangle> dow = new List<Rectangle>();
                int up_y = 0, dow_y = 0;
                bool flag_up = false;

                int di = 0;

                if (listRect == null) return;

                for (int i = 0; i < listRect.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);
                    int cou = 0;
                    full_tesseract.SetVariable("tessedit_reset_classifier", "1");
                    string temp;
                    using (var pages = full_tesseract.Process(ch))
                    {
                        temp = pages.GetText();
                    }
                    while (temp.Length > 3)
                    {
                        Image<Gray, byte> temp2 = new Image<Gray, byte>(ch.ToImage<Gray, byte>().Data);
                        temp2 = temp2.Erode(2);
                        ch = temp2.ToBitmap();
                        full_tesseract.SetVariable("tessedit_reset_classifier", "1");
                        using (var pages = full_tesseract.Process(ch))
                        {
                            temp = pages.GetText();
                        }
                        cou++;
                        if (cou > 10)
                        {
                            listRect.RemoveAt(i);
                            i--;
                            di = 0;
                            break;
                        }
                        di = cou;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    for (int j = i; j < listRect.Count; j++)
                    {
                        if (listRect[i].Y > listRect[j].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[j].Y;
                            dow_y = listRect[i].Y;
                            break;
                        }
                        else if (listRect[j].Y > listRect[i].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[i].Y;
                            dow_y = listRect[j].Y;
                            break;
                        }
                        if (flag_up == true) break;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                    {
                        up.Add(listRect[i]);
                    }
                    else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                    {
                        dow.Add(listRect[i]);
                    }
                }

                if (flag_up == false) dow = listRect;

                for (int i = 0; i < up.Count; i++)
                {
                    for (int j = i; j < up.Count; j++)
                    {
                        if (up[i].X > up[j].X)
                        {
                            Rectangle w = up[i];
                            up[i] = up[j];
                            up[j] = w;
                        }
                    }
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    for (int j = i; j < dow.Count; j++)
                    {
                        if (dow[i].X > dow[j].X)
                        {
                            Rectangle w = dow[i];
                            dow[i] = dow[j];
                            dow[j] = w;
                        }
                    }
                }

                int x = 12;
                int c_x = 0;

                for (int i = 0; i < up.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                    Bitmap o = ch;

                    string temp;
                    if (i < 2)
                    {
                        temp = Ocr(ch, false, true); // nhan dien so
                    }
                    else
                    {
                        temp = Ocr(ch, false, false);// nhan dien chu
                    }

                    zz += temp;
                    box[i].Location = new Point(x + i * 50, 290);
                    box[i].Size = new Size(50, 100);
                    box[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i].Image = ch;
                    box[i].Update();
                    c_x++;
                }
                zz += "\r\n";
                for (int i = 0; i < dow.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);

                    string temp = Ocr(ch, false, true); // nhan dien so
                    zz += temp;
                    box[i + c_x].Location = new Point(x + i * 50, 390);
                    box[i + c_x].Size = new Size(50, 100);
                    box[i + c_x].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i + c_x].Image = ch;
                    box[i + c_x].Update();

                }
                bienso = zz.Replace("\n", "");
                bienso = bienso.Replace("\r", "");

                bienso_text = zz;

            }
        }

        private void loadImagebtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image (*.bmp; *.jpg; *.jpeg; *.png) |*.bmp; *.jpg; *.jpeg; *.png|All files (*.*)|*.*||";
            dlg.InitialDirectory = Application.StartupPath + "\\ImageTest";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string startupPath = dlg.FileName;

            Image temp1;
            string temp2, temp3;
            Reconize(startupPath, out temp1, out temp2, out temp3);
            pictureBox3.Image = temp1;
            if (temp3 == "")
                platetxt.Text = "Cannot recognize license plate !";
            else
                platetxt.Text = temp3;
        }
    }
}

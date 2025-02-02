using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System.Drawing;

namespace carpark_system
{
    internal class FindContours
    {
        public int count = 0;
        /// <param name="colorImage">Source color image.</param>
        /// <param name="thresholdValue">Value used for thresholding.</param>
        /// <param name="processedGray">Resulting gray image.</param>
        /// <param name="processedColor">Resulting color image.</param>
        public int IdentifyContours(Bitmap colorImage, int thresholdValue, bool invert, out Bitmap processedGray, out Bitmap processedColor, out List<Rectangle> list)
        {
            List<Rectangle> listR = new List<Rectangle>();
            #region Conversion To grayscale
            Image<Gray, byte> grayImage = colorImage.ToImage<Gray, byte>();
            //grayImage = grayImage.Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            Image<Gray, byte> bi = new Image<Gray, byte>(grayImage.Width, grayImage.Height);
            Image<Bgr, byte> color = colorImage.ToImage<Bgr, byte>();

            #endregion

            #region tim gia tri thresh de co so ky tu lon nhat

            double thr = 0;
            if (thr == 0)
            {
                thr = grayImage.GetAverage().Intensity;
            }

            Rectangle[] li = new Rectangle[9];
            Image<Bgr, byte> color_b = colorImage.ToImage<Bgr, byte>();
            Image<Gray, byte> src_b = grayImage.Clone();
            Image<Gray, byte> bi_b = bi.Clone();
            Image<Bgr, byte> color2;
            Image<Gray, byte> src;
            Image<Gray, byte> bi2;
            int c = 0, c_best = 0;

            for (double value = 0; value <= 127; value += 3)
            {
                for (int s = -1; s <= 1 && s + value != 1; s += 2)
                {
                    color2 = colorImage.ToImage<Bgr, byte>();

                    bi2 = bi.Clone();
                    listR.Clear();

                    c = 0;
                    double t = 127 + value * s;
                    src = grayImage.ThresholdBinary(new Gray(t), new Gray(255));

                    // Tạo danh sách chứa contours
                    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

                    // Tìm contours trong ảnh `src`
                    CvInvoke.FindContours(src, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

                    for (int i = 0; i < contours.Size; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        {
                            Rectangle rect = CvInvoke.BoundingRectangle(contour); // Lấy bounding box của contour

                            if (rect.Width > 20 && rect.Width < 150
                                && rect.Height > 80 && rect.Height < 180
                                && rect.X > 20)
                            {
                                c++;
                                CvInvoke.DrawContours(color2, contours, i, new MCvScalar(0, 255, 255), 3); // Vẽ contour
                                CvInvoke.Rectangle(color2, rect, new MCvScalar(0, 255, 0), 2); // Vẽ khung chữ nhật quanh contour
                                listR.Add(rect); // Lưu bounding box vào danh sách
                            }
                        }
                    }
                    double avg_h = 0;
                    double dis = 0;
                    for (int i = 0; i < c; i++)
                    {
                        avg_h += listR[i].Height;
                        for (int j = i + 1; j < c; j++)
                        {
                            if ((listR[j].X < (listR[i].X + listR[i].Width) && listR[j].X > listR[i].X)
                                && (listR[j].Y < (listR[i].Y + listR[i].Width) && listR[j].Y > listR[i].Y))
                            {
                                //avg_h -= listR[j].Height;
                                listR.RemoveAt(j);
                                c--;
                                j--;
                            }
                            else if ((listR[i].X < (listR[j].X + listR[j].Width) && listR[i].X > listR[j].X)
                                && (listR[i].Y < (listR[j].Y + listR[j].Width) && listR[i].Y > listR[j].Y))
                            {
                                avg_h -= listR[i].Height;
                                listR.RemoveAt(i);
                                c--;
                                i--;
                                break;
                            }

                        }
                    }
                    avg_h = avg_h / c;
                    for (int i = 0; i < c; i++)
                    {
                        dis += Math.Abs(avg_h - listR[i].Height);
                    }

                    if (c <= 8 && c > 1 && c > c_best && dis <= c * 8)
                    {
                        listR.CopyTo(li);
                        c_best = c;
                        color_b = color2;
                        bi_b = bi2;
                        src_b = src;
                    }
                }
                if (c_best == 8) break;
            }

            count = c_best;
            grayImage = src_b;
            color = color_b;
            bi = bi_b;
            listR.Clear();
            for (int i = 0; i < li.Length; i++)
            {
                if (li[i].Height != 0) listR.Add(li[i]);
            }
            #endregion

            #region Asigning output
            processedColor = color.ToBitmap();
            processedGray = grayImage.ToBitmap();
            list = listR;
            #endregion
            return count;
        }
    }
}

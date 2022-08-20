using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.IO;

namespace DemoButtons
{
    internal class STU
    {

        static int m_penDataOptionMode = -1;
        static int penDataType;
        static List<wgssSTU.IPenData> m_penData;
        static List<wgssSTU.IPenDataTimeCountSequence> m_penTimeData = new List<wgssSTU.IPenDataTimeCountSequence>();
        static wgssSTU.ICapability m_capability;
        static wgssSTU.IInformation m_information;
        static float inkWidthMM = 0.7F;
        static Pen m_penInk = new Pen(Color.DarkBlue, inkWidthMM / 25.4F);
       



        public void Main()
        {

            m_penInk.StartCap = m_penInk.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            m_penInk.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            wgssSTU.Tablet m_tablet = new wgssSTU.Tablet();

            wgssSTU.UsbDevices usbDevices = new wgssSTU.UsbDevices();
            if (usbDevices.Count != 0)
            {
                try
                {
                    wgssSTU.IUsbDevice usbDevice = usbDevices[0]; // select a device
                    wgssSTU.IErrorCode ec = m_tablet.usbConnect(usbDevice, true);
                    if (ec.value == 0)
                    {

                      m_capability =  m_tablet.getCapability();
                      m_information = m_tablet.getInformation();
                        m_penData = new List<wgssSTU.IPenData>();



                        SaveImage(m_capability);
                        penDataType = m_penDataOptionMode;
                    

                    }
                    else
                    {
                        throw new Exception(ec.message);
                    }

                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No STU devices attached");
            }

        }


      

        static string SaveImage(wgssSTU.ICapability m_capability)
        {
            var Timestamp = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
            try
            {
                Bitmap bitmap = GetImage(new Rectangle(0, 0, m_capability.screenWidth, m_capability.screenHeight));
                string saveLocation = System.Environment.CurrentDirectory + "\\" + "signature_output_" + Timestamp + ".jpg";
                bitmap.Save(saveLocation, ImageFormat.Jpeg);
                System.IO.MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                var SigBase64 = Convert.ToBase64String(byteImage);
                Console.WriteLine("----------------Base64------------------=" + SigBase64);
                return SigBase64;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                return "Error";
            }

        }


        // Draw an image with the existed points.
        static Bitmap GetImage(Rectangle rect)
        {
            Bitmap retVal = null;
            Bitmap bitmap = null;
            SolidBrush brush = null;
            try
            {
                bitmap = new Bitmap(rect.Width, rect.Height);
                Graphics graphics = Graphics.FromImage(bitmap);

                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                brush = new SolidBrush(Color.White);
                graphics.FillRectangle(brush, 0, 0, rect.Width, rect.Height);

                if (m_penDataOptionMode == (int)PenDataOptionMode.PenDataOptionMode_TimeCountSequence)
                {
                    for (int i = 1; i < m_penTimeData.Count; i++)
                    {
                        PointF p1 = tabletToScreen(m_penTimeData[i - 1]);
                        PointF p2 = tabletToScreen(m_penTimeData[i]);

                        if (m_penTimeData[i - 1].sw > 0 || m_penTimeData[i].sw > 0)
                        {
                            graphics.DrawLine(m_penInk, p1, p2);
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < m_penData.Count; i++)
                    {
                        PointF p1 = tabletToScreen(m_penData[i - 1]);
                        PointF p2 = tabletToScreen(m_penData[i]);

                        if (m_penData[i - 1].sw > 0 || m_penData[i].sw > 0)
                        {
                            graphics.DrawLine(m_penInk, p1, p2);
                        }
                    }
                }

                retVal = bitmap;
                bitmap = null;
            }
            finally
            {
                if (brush != null)
                    brush.Dispose();
                if (bitmap != null)
                    bitmap.Dispose();
            }
            return retVal;
        }

        static Point tabletToScreen(wgssSTU.IPenData penData)
        {
            // Screen means LCD screen of the tablet.
            return Point.Round(new PointF((float)penData.x * m_capability.screenWidth / m_capability.tabletMaxX, (float)penData.y * m_capability.screenHeight / m_capability.tabletMaxY));
        }


    }
}

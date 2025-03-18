using Basler.Pylon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Markup;

namespace WPF_VisionPro_2025.Models
{
    public class ClassCamera
    {
        Camera camera;
        List<ICameraInfo> listCamera;
        Bitmap bmp;
        PixelDataConverter Converter = new PixelDataConverter();
        Stopwatch sw;
        bool isOK, isNG;
        public ClassCamera()
        {
            Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "500");
            InitCamera();
        }
        private void InitCamera()
        {
            listCamera = CameraFinder.Enumerate();
            camera = new Camera(listCamera[0]);
            sw = new Stopwatch();
            isOK = isNG = false;

            camera.ConnectionLost += Camera_ConnectionLost;
            camera.StreamGrabber.ImageGrabbed += StreamGrabber_ImageGrabbed;

            camera.Open();
        }
        private void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                IGrabResult grabResult = e.GrabResult;

                if (grabResult.IsValid)
                {
                    bmp = new Bitmap(grabResult.Width, grabResult.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    BitmapData bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                    Converter.OutputPixelFormat = PixelType.BGRA8packed;
                    IntPtr ptrBmp = bmpData.Scan0;
                    Converter.Convert(ptrBmp, bmpData.Stride * bmp.Height, grabResult);
                    bmp.UnlockBits(bmpData);
                    isOK = true;

                }
            }
            catch (Exception ex)
            {
                isNG = true;
                MessageBox.Show($"{ex.Message}");
            }
        }
        public Bitmap Grab()
        {
            isOK = isNG = false;
            if (camera.StreamGrabber.IsGrabbing)
            {
                camera.StreamGrabber.Stop();
            }
            camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);
            camera.StreamGrabber.Start(1, GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
            sw.Restart();
            while (true)
            {
                if (isOK) return bmp;
                if (isNG) break;
                if (sw.ElapsedMilliseconds > 3000) break;
            }
            return null;
        }
        private void Camera_ConnectionLost(object sender, EventArgs e)
        {
            camera.Close();
        }
        public void Close()
        {
            if (camera.IsOpen)
            {
                camera.Close();
                camera.Dispose();
            }
                camera.Dispose();
        }
        public ImageSource BitmapToImageSource(Bitmap bmp)
        {
            if (bmp == null)
            {
                return null;
            }
            using (MemoryStream mm = new MemoryStream())
            {
                bmp.Save(mm, System.Drawing.Imaging.ImageFormat.Bmp);
                mm.Position = 0;

                BitmapImage bmpImage = new BitmapImage();
                bmpImage.BeginInit();
                bmpImage.StreamSource = mm;
                bmpImage.CacheOption = BitmapCacheOption.OnLoad;
                bmpImage.EndInit();
                return bmpImage;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xaml;
using Microsoft.Samples.Kinect.InteractionGallery.Models;
using PixelFormat = System.Windows.Media.PixelFormat;

namespace Microsoft.Samples.Kinect.InteractionGallery.Utilities
{
    public class ImageHelper
    {
        [DllImport("gdi32")]
        static extern int DeleteObject(IntPtr o);

        public enum AdjustMode
        {
            HW,
            W,
            H,
            Cut
        }

        public static Byte[] ByteBufferFromImage(BitmapImage imageSource)
        {
            var ms = new MemoryStream();
            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(imageSource));
            pngEncoder.Save(ms);

            return ms.GetBuffer();
        }
        internal const string DefaultQuestionScreenModelContent = "Content/QuestionScreen/QustionScreenContent.xaml";


        public static ImageSource ChangeSize(string imgSourcePath, double ratio,AdjustMode mode)
        {
            var originalImage = GetImage(imgSourcePath);
            int towidth =(int)(originalImage.Width*ratio);
            int toheight = (int)(originalImage.Height * ratio);
            return ChangeSize(originalImage, towidth, toheight,mode);
        }

        public static ImageSource ChangeSize(string imgSourcePath, int width, int height, AdjustMode mode)
        {

            var originalImage = GetImage(imgSourcePath);
            return ChangeSize(originalImage, width, height, mode);

        }

        public static ImageSource ChangeSize(Image originalImage, int width, int height, AdjustMode mode)
        {
            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case AdjustMode.HW://指定高宽缩放（可能变形）                 
                    break;
                case AdjustMode.H://指定宽，高按比例                     
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case AdjustMode.W://指定高，宽按比例 
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case AdjustMode.Cut://指定高宽裁减（不变形）                 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片 
            Bitmap bitmap = new Bitmap(towidth, toheight);

            //新建一个画板 
            Graphics g = Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充 
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);

            try
            {
                IntPtr ip = bitmap.GetHbitmap();
                BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ip);
                return bitmapSource;
                //保存缩略图
               // bitmap.Save(thumbnailPath, imgtype);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }      

        private static Image GetImage(string imgSourcePath)
        {
            Uri patUri = PackUriHelper.CreatePackUri(imgSourcePath);
            Image originalImage;
            try
            {
                using (Stream questionModelsStream = Application.GetResourceStream(patUri).Stream)
                {
                    originalImage = Image.FromStream(questionModelsStream);
                }
            }
            catch (Exception)
            {
                throw new FileNotFoundException("there no resouce file in this path");
            }
            return originalImage;
        }


    }
}

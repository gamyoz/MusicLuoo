using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace MusicLuooUnity
{
    /*
     *计算机名称：JT-2207
     *创建日期：2016/5/26 16:52:38
     *描述：PictureHelper的说明信息
    */
    public class PictureHelper
    {
        #region 生成缩略图

        /// <summary>
        /// 改变图片大小
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="w">最大宽</param>
        /// <param name="h">高度</param>
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int w, int h)
        {
            string path = Path.GetDirectoryName(thumbnailPath);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            Image originalImage = Image.FromFile(originalImagePath);

            int ow = originalImage.Width;
            int oh = originalImage.Height;
            int towidth = ow, toheight = oh;

            if (w > 0 && ow > w)
            {
                towidth = w;
                toheight = oh * towidth / ow;
            }
            if (h > 0 && oh > h)
            {
                toheight = h;
                towidth = ow * toheight / oh;
            }

            Image bitmap = new Bitmap(towidth, toheight);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);

            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight));

            bitmap.Save(thumbnailPath, ImageFormat.Bmp);
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }

        public static void ChangeSize(int w, int h, ref Image img)
        {
            //图片宽度调整
            if (img.Width > w)
            {
                int h1 = img.Height * w / img.Width;
                Image bitmap = new Bitmap(w, h1);
                Graphics g = Graphics.FromImage(bitmap);
                g.InterpolationMode = InterpolationMode.High;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(img, new Rectangle(0, 0, w, h1));
                img = bitmap;
            }
            //图片高度调整
            if (img.Height > h)
            {
                int w1 = img.Width * h / img.Height;
                Image bitmap = new Bitmap(w1, h);
                Graphics g = Graphics.FromImage(bitmap);
                g.InterpolationMode = InterpolationMode.High;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(img, new Rectangle(0, 0, w1, h));
                img = bitmap;
            }
        }
        #endregion
        public static void SysLog(string message)
        {
            List<string> str = new List<string>();
            str.Add("发生时间：" + DateTime.Now);
            str.Add("信息：" + message);
            str.Add("=========================================================");
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "Log\\";
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }

            fileName += DateTime.Now.ToString("yyyyMMdd") + ".txt";
            WriteFile(fileName, str);
        }

        public static string WriteFile(string xFile, List<string> xContent, bool append = true)
        {
            string fRes;
            if (!File.Exists(xFile))
            {
                File.Create(xFile).Close();
                fRes = "Create";
            }
            else
                fRes = "Edit";
            StreamWriter w = new StreamWriter(xFile, append);
            foreach (var str in xContent)
                w.WriteLine(str);
            w.Flush();
            w.Close();
            return fRes;
        }

        public static bool GetPicThumbnail(string sFile, string outPath, int flag)
        {
            Image iSource = Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            //以下代码为保存图片时，设置压缩质量  
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100  
            EncoderParameter eParam = new EncoderParameter(Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    iSource.Save(outPath, jpegICIinfo, ep);//dFile是压缩后的新路径  
                }
                else
                {
                    iSource.Save(outPath, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                iSource.Dispose();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using System.Web;
using FifaFanApp.DAL;
using ServiceStack;

namespace FifaFanApp.BLL
{
    public class ImageProcessor
    {
        public class Resize
        {
            public string Id { get; set; }
            public string Size { get; set; }
            public string Directory { get; set; }
        }

        public class ImageResizer
        {
            const int PlayerWidthHeight = 40;
            const int ClubNationWidthHeight = 20;
            private readonly string PlayerThumbDir = "~/Content/Uploads/Players".MapHostAbsolutePath();
            private readonly string NationThumbDir = "~/Content/Uploads/Nation".MapHostAbsolutePath();
            private readonly string ClubThumbDir = "~/Content/Uploads/Club".MapHostAbsolutePath();


            public string WriteImage(Stream ms, string uploadChoice)
            {
                var hash = GetMd5Hash(ms);
                ms.Position = 0;
                var fileName = hash + ".png";
                using (var img = Image.FromStream(ms))
                {
                    if (uploadChoice == "Player")
                    {
                        img.Save(PlayerThumbDir.CombineWith(fileName));
                        var stream = Resize(img, PlayerWidthHeight, PlayerWidthHeight);
                        System.IO.File.WriteAllBytes(PlayerThumbDir.CombineWith(fileName), stream.ReadFully());
                        return "~/Content/Uploads/Players".CombineWith(fileName);
                    }
                    if (uploadChoice == "Nation")
                    {
                        img.Save(NationThumbDir.CombineWith(fileName));
                        var stream = Resize(img, ClubNationWidthHeight, ClubNationWidthHeight);
                        System.IO.File.WriteAllBytes(NationThumbDir.CombineWith(fileName), stream.ReadFully());
                        return "~/Content/Uploads/Nation".CombineWith(fileName);

                    }
                    if (uploadChoice == "Club")
                    {
                        img.Save(ClubThumbDir.CombineWith(fileName));
                        var stream = Resize(img, ClubNationWidthHeight, ClubNationWidthHeight);
                        System.IO.File.WriteAllBytes(ClubThumbDir.CombineWith(fileName), stream.ReadFully());
                        return "~/Content/Uploads/Club".CombineWith(fileName);
                    }
                    throw new HttpException(404, "was not found");
                }
            }

            public Stream Get(Resize request)
            {

                var imagePath = request.Directory.CombineWith(request.Id + ".png");
                if (request.Id == null || !File.Exists(imagePath))
                    throw new HttpException(404, "was not found");

                using (var stream = File.OpenRead(imagePath))
                using (var img = Image.FromStream(stream))
                {
                    var parts = request.Size == null ? null : request.Size.Split('x');
                    int width = img.Width;
                    int height = img.Height;

                    if (parts != null && parts.Length > 0)
                        int.TryParse(parts[0], out width);

                    if (parts != null && parts.Length > 1)
                        int.TryParse(parts[1], out height);

                    return Resize(img, width, height);
                }
            }

            public static string GetMd5Hash(Stream stream)
            {
                var hash = MD5.Create().ComputeHash(stream);
                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }

            public static Stream Resize(Image img, int newWidth, int newHeight)
            {
                if (newWidth != img.Width || newHeight != img.Height)
                {
                    var ratioX = (double)newWidth / img.Width;
                    var ratioY = (double)newHeight / img.Height;
                    var ratio = Math.Max(ratioX, ratioY);
                    var width = (int)(img.Width * ratio);
                    var height = (int)(img.Height * ratio);

                    var newImage = new Bitmap(width, height);
                    Graphics.FromImage(newImage).DrawImage(img, 0, 0, width, height);
                    img = newImage;

                    if (img.Width != newWidth || img.Height != newHeight)
                    {
                        var startX = (Math.Max(img.Width, newWidth) - Math.Min(img.Width, newWidth)) / 2;
                        var startY = (Math.Max(img.Height, newHeight) - Math.Min(img.Height, newHeight)) / 2;
                        img = Crop(img, newWidth, newHeight, startX, startY);
                    }
                }

                var ms = new MemoryStream();
                img.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                return ms;
            }


            public static Image Crop(Image Image, int newWidth, int newHeight, int startX = 0, int startY = 0)
            {
                if (Image.Height < newHeight)
                    newHeight = Image.Height;

                if (Image.Width < newWidth)
                    newWidth = Image.Width;

                using (var bmp = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb))
                {
                    bmp.SetResolution(72, 72);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.DrawImage(Image, new Rectangle(0, 0, newWidth, newHeight), startX, startY, newWidth, newHeight, GraphicsUnit.Pixel);

                        var ms = new MemoryStream();
                        bmp.Save(ms, ImageFormat.Png);
                        Image.Dispose();
                        var outimage = Image.FromStream(ms);
                        return outimage;
                    }
                }
            }
            private static string AssertDir(string dirPath)
            {
                if (!Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath);
                return dirPath;
            }

        }
    }
}
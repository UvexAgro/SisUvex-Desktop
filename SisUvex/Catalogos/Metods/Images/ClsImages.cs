using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisUvex.Catalogos.Metods.Images
{
    internal class ClsImages
    {
        public static string Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
        static string[] extensiones = new[] { ".jpg", ".png", ".jpeg", ".bmp" };

        public static Image? GetImageFromPathWithoutExtentionFile(string imagePath)
        {
            Image? result = null;

            foreach (string ext in extensiones)
            {
                string imagePathExt = Path.Combine(imagePath + ext);

                result = GetImageFromPath(imagePathExt);

                if (result != null)
                    return result;
            }

            return null;
        }

        public static Image? GetImageFromPath(string imagePath)
        {
            if (File.Exists(imagePath) && new FileInfo(imagePath).Length > 0)
            {
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    using (Image original = Image.FromStream(stream))
                    {
                        return (Image)original.Clone();
                    }
                }
            }

            return null;
        }

        public static ImageWithExtension? GetImageWithExtensionFromPathWithoutExtension(string pathWithoutExtension)
        {
            string[] supportedExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

            foreach (var ext in supportedExtensions)
            {
                string fullPath = pathWithoutExtension + ext;
                if (File.Exists(fullPath))
                {
                    try
                    {
                        using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                        var image = Image.FromStream(fs);
                        return new ImageWithExtension
                        {
                            Image = (Image)image.Clone(),
                            Extension = ext
                        };
                    }
                    catch
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        public static System.Drawing.Imaging.ImageFormat GetImageFormatFromExtension(string extension)
        {
            return extension.ToLower() switch
            {
                ".jpg" or ".jpeg" => System.Drawing.Imaging.ImageFormat.Jpeg,
                ".bmp" => System.Drawing.Imaging.ImageFormat.Bmp,
                ".gif" => System.Drawing.Imaging.ImageFormat.Gif,
                ".tiff" => System.Drawing.Imaging.ImageFormat.Tiff,
                _ => System.Drawing.Imaging.ImageFormat.Png,
            };
        }

    }
    public class ImageWithExtension
    {
        public Image? Image { get; set; }
        public string Extension { get; set; } = ".png"; // default si no se sabe
    }
}

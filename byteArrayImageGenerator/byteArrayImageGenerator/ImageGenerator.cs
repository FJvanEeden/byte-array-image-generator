using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace byteArrayImageGenerator
{
    internal class ImageGenerator
    {
        public static Image GenerateImageFromByteArr(IEnumerable<byte> rawImageData, int width, int height)
        {
            byte[] newData = rawImageData.ToArray();

            using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
                IntPtr pNative = bmpData.Scan0;
                Marshal.Copy(newData, 0, pNative, newData.Length - 1);

                bmp.UnlockBits(bmpData);
                return (Image)bmp.Clone();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace byteArrayImageGenerator
{
  class ImageGenerator
  {
    // Made static to test
    public static Image GenerateImageFromByteArr(IEnumerable<byte> rawImageData, int width, int height)
    {
      var x = 0;
      int i;
      byte[] pixel = new byte[4];
      byte[] newData = new byte[width * height * 4];

      foreach (var data in rawImageData)
      {
        i = x % 4;
        if (x >= 0 && i == 0)
        {
          byte r = pixel[0];
          byte g = pixel[1];
          byte b = pixel[2];
          byte a = pixel[3];
          byte[] newPixel = new byte[] { b, g, r, a };
          Array.Copy(newPixel, 0, newData, x, 4);
        }
        pixel[i] = data;
        x++;
      }

      i = x % 4;
      if (x >= 0 && i == 0)
      {
        byte r = pixel[0];
        byte g = pixel[1];
        byte b = pixel[2];
        byte a = pixel[3];
        byte[] newPixel = new byte[] { b, g, r, a };
        Array.Copy(newPixel, 0, newData, x, 4);
      }

      using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
      {
        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
        Marshal.Copy(newData, 0, bmpData.Scan0, newData.Length);

        bmp.UnlockBits(bmpData);
        return (Image)bmp.Clone();
      }
    }
  }
}

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace byteArrayImageGenerator
{
  class ImageGenerator
  {
    public ImageGenerator()
    {
    }

    public static bool WriteBitmapFile(string filename, int width, int height, byte[] rawImageData, PixelFormat pixelFormat)
    {
      byte[] newData = new byte[rawImageData.Length];

      for (int x = 0; x < rawImageData.Length; x += 4)
      {
        byte[] pixel = new byte[4];
        Array.Copy(rawImageData, x, pixel, 0, 4);

        byte r = pixel[0];
        byte g = pixel[1];
        byte b = pixel[2];
        byte a = pixel[3];

        byte[] newPixel = new byte[] { b, g, r, a };

        Array.Copy(newPixel, 0, newData, x, 4);
      }

      rawImageData = newData;

      using (var stream = new MemoryStream(rawImageData))
      using (var bmp = new Bitmap(width, height, pixelFormat))
      {
        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

        IntPtr pNative = bmpData.Scan0;
        Marshal.Copy(rawImageData, 0, pNative, rawImageData.Length);

        bmp.UnlockBits(bmpData);

        bmp.Save(filename, ImageFormat.Png);
      }
      return true;
    }

    // For testing purposes ONLY
    public static byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
      MemoryStream ms = new MemoryStream();
      imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
      return ms.ToArray();
    }

    public static Image byteArrayToImage(byte[] byteArrayIn)
    {
      MemoryStream ms = new MemoryStream(byteArrayIn);
      Image returnImage = Image.FromStream(ms);
      return returnImage;
    }
  }
}

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace byteArrayImageGenerator
{
  class ImageGenerator : IEnumerable // Removed class interface
  {
    private object[] _objects; // Test implementation

    public ImageGenerator()
    {
      
    }

    // Made static to test
    public static Image GenerateImageFromByteArr(byte[] rawImageData, int width, int height, ImageFormat imageFormat)
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
      using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
      {
        BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

        IntPtr pNative = bmpData.Scan0;
        Marshal.Copy(rawImageData, 0, pNative, rawImageData.Length);

        bmp.UnlockBits(bmpData);
        bmp.Save(stream, imageFormat);
        return (Image)bmp.Clone();
      }
    }

    // Test implementation
    public IEnumerator GetEnumerator()
    {
      return new ArrayEnumerator(_objects);
    }

    private class ArrayEnumerator : IEnumerator
    {
      private object[] mValues;

      private int _currentIndex = -1;

      public ArrayEnumerator(object[] values)
      {
        mValues = values;
      }

      public bool MoveNext()
      {
        _currentIndex++;
        return (_currentIndex < mValues.Length);
      }

      public object Current { get; private set; } = 0;
      
      public void Reset()
      {
        _currentIndex = 0;
      }
    }
  }
}

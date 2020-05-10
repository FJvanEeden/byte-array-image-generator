using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace byteArrayImageGenerator
{
  internal class Program
    {
    static public void Main(String[] args)
    {
      Console.WriteLine("For static testing function.");

      //Test values
      //string folderPath = @"C:\Users\TKK\Documents\Onyx_projects\file.png";
      string folderPath = @"C:\temp\file.png";
      var width = 1920;
      var height = 1080;

      //Test #12
      var image = RedImage(width, height);
      image.ToArray();

      Image success = ImageGenerator.GenerateImageFromByteArr(image, width, height);
      success.Save(folderPath);
    }

    private static IEnumerable<byte> RedImage(int width, int height)
    {
      int index = 0;
      var pixel = new byte[] { 255, 0, 0, 255 };
      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          for (int p = 0; p < 4; p++)
          {
            yield return pixel[index % 4];
            index++;
          }
        }
      }
    }
  }
}
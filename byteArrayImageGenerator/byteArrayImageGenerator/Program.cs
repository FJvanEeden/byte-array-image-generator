using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace byteArrayImageGenerator
{
  class Program
  {
    static public void Main(String[] args)
    {
      Console.WriteLine("To Test function.");

      //Test values
      string folderPath = @"C:\Users\TKK\Documents\Onyx_projects\file.png";
      var width = 1000;
      var height = 700;
      byte[] testArr = { 255, 255, 0, 255, 255, 0, 255, 255, 0, 255, 0, 255, 0, 0, 255, 255 };

      //Test #6
      Image success = ImageGenerator.GenerateImageFromByteArr(testArr, width, height, ImageFormat.Png);
      success.Save(folderPath);
    }
  }
}

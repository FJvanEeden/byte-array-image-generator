using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Remoting.Channels;

namespace byteArrayImageGenerator
{
  class Program
  {
    static public void Main(String[] args)
    {
      Console.WriteLine("To Test function.");

      //Test values
      string folderPath = @"C:\Users\TKK\Documents\Onyx_projects\file.png";
      var path = @"C:\Users\TKK\Documents\Onyx_projects\7zqm3qahhqo41.png";

      var width = 225;
      var height = 225;
      byte[] testArr = { 255, 255, 0, 255, 255, 0, 255, 255, 0, 255, 0, 255, 0, 0, 255, 255 };


      //Test #6
      Image success = ImageGenerator.WriteBitmapFile(testArr, width, height, ImageFormat.Png);
      success.Save(folderPath);

    }
  }
}

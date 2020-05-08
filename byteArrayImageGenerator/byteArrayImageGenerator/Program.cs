using System;
using System.Drawing;

namespace byteArrayImageGenerator
{
  class Program
  {
    static public void Main(String[] args)
    {
      Console.WriteLine("For static testing function.");

      //Test values
      string folderPath = @"C:\Users\TKK\Documents\Onyx_projects\file.png";
      var width = 100;
      var height = 100;
      // Array Output = { Yellow, Yellow, Yellow, Yellow, Blue, Blue, Blue, Blue, White, White, White, White, Red, Red, Red, Red }
      byte[] testArr = { 255, 255, 0, 255,  255, 255, 0, 255,  255, 255, 0, 255,  255, 255, 0, 255,
                          0, 0, 255, 255,  0, 0, 255, 255,  0, 0, 255, 255,  0, 0, 255, 255,
                          255, 255, 255, 255,  255, 255, 255, 255,  255, 255, 255, 255,  255, 255, 255, 255,
                          255, 0, 0, 255,  255, 0, 0, 255,  255, 0, 0, 255,  255, 0, 0, 255 };

      //Test #6
      Image success = ImageGenerator.GenerateImageFromByteArr(testArr, width, height);
      success.Save(folderPath);
    }
  }
}

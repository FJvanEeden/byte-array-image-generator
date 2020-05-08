using System;
using System.Collections.Generic;
using System.Drawing;

namespace byteArrayImageGenerator
{
    internal class Program
    {
        static public void Main(String[] args)
        {
            Console.WriteLine("For static testing function.");

            //Test values
            string folderPath = @"C:\temp\file.png";
            var width = 100;
            var height = 100;
            // Array Output = { Yellow, Yellow, Yellow, Yellow, Blue, Blue, Blue, Blue, White, White, White, White, Red, Red, Red, Red }
            byte[] testArr = { 255, 255, 0, 255,  255, 255, 0, 255,  255, 255, 0, 255,  255, 255, 0, 255,
                          0, 0, 255, 255,  0, 0, 255, 255,  0, 0, 255, 255,  0, 0, 255, 255,
                          255, 255, 255, 255,  255, 255, 255, 255,  255, 255, 255, 255,  255, 255, 255, 255,
                          255, 0, 0, 255,  255, 0, 0, 255,  255, 0, 0, 255,  255, 0, 0, 255 };

            //Test #6
            var image = RedImage(width, height);
            Image success = ImageGenerator.GenerateImageFromByteArr(image, width, height);
            success.Save(folderPath);
        }

        private static IEnumerable<byte> RedImage(int width, int height)
        {
            int index = 0;
            var pixel = new byte[] { 255, 0, 0, 255 };
            for(int x = 0; x  < width; x ++)
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
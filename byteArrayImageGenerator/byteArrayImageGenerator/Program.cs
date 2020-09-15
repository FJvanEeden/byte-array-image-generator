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
            //string folderPath = @"C:\Users\TKK\Documents\Onyx_projects\file.png";
            string folderPath = @"C:\temp\file.png";
            var width = 1920;
            var height = 1080;

            //Test #12
            var image = RedImageWithBlueCircle(width, height);

            Image success = ImageGenerator.GenerateImageFromByteArr(image, width, height);
            success.Save(folderPath);
        }

        private static IEnumerable<byte> RedImage(int width, int height)
        {
            int index = 0;
            var pixel = new byte[] { 255, 0, 0, 255 };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int p = 0; p < 4; p++)
                    {
                        yield return pixel[index % 4];
                        index++;
                    }
                }
            }
        }

        private static IEnumerable<byte> RedImageWithBlueCircle(int width, int height)
        {
            int index = 0;
            // { b, g, r, a };
            var red = new byte[] { 0, 0, 255, 255 };
            var blue = new byte[] { 255, 0, 0, 255 };
            var green = new byte[] { 0, 255, 0, 255 };

            int blueXOffset = 300;
            int blueYOffset = 200;
            int blueInnerRadius = 300;
            int blueOuterRadius = 500;

            int greenXOffset = 800;
            int greenYOffset = 700;
            int greenInnerRadius = 400;
            int greenOuterRadius = 500;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (((x - blueXOffset) * (x - blueXOffset) + (y - blueYOffset) * (y - blueYOffset) > blueInnerRadius * blueInnerRadius) && ((x - blueXOffset) * (x - blueXOffset) + (y - blueYOffset) * (y - blueYOffset) < blueOuterRadius * blueOuterRadius))
                    {
                        for (int p = 0; p < 4; p++)
                        {
                            yield return blue[index % 4];
                            index++;
                        }
                    }
                    else if (((x - greenXOffset) * (x - greenXOffset) + (y - greenYOffset) * (y - greenYOffset) > greenInnerRadius * greenInnerRadius) && ((x - greenXOffset) * (x - greenXOffset) + (y - greenYOffset) * (y - greenYOffset) < greenOuterRadius * greenOuterRadius))
                    {
                        for (int p = 0; p < 4; p++)
                        {
                            yield return green[index % 4];
                            index++;
                        }
                    }
                    else
                    {
                        for (int p = 0; p < 4; p++)
                        {
                            yield return red[index % 4];
                            index++;
                        }
                    }
                }
            }
        }
    }
}
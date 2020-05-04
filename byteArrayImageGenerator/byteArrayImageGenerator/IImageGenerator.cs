using System.Drawing;
using System.Drawing.Imaging;

namespace byteArrayImageGenerator
{
  interface IImageGenerator
  {
    Image GenerateImage(byte[] stream, int width, int height, ImageFormat outputImageType);
  }
}
using System.Drawing;
using System.Drawing.Imaging;

namespace byteArrayImageGenerator
{
  public interface IImageGenerator
  {
    Image GenerateImage(byte[] stream, int width, int height, PixelFormat pixelFormat);
  }
}
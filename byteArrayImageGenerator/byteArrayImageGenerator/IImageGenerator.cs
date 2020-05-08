using System.Drawing;
using System.Drawing.Imaging;

namespace byteArrayImageGenerator
{
  public interface IImageGenerator
  {
    Image GenerateImageFromByteArr(byte[] rawImageData, int width, int height, ImageFormat imageFormat);
  }
}
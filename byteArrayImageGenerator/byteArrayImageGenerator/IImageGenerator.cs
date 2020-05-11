using System.Drawing;

namespace byteArrayImageGenerator
{
  public interface IImageGenerator
  {
    Image GenerateImageFromByteArr(byte[] rawImageData, int width, int height);
  }
}
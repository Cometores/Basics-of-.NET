using System.Drawing;

namespace ImageProcessor.Filters;

public interface IImageFilter
{
    Bitmap Apply(Bitmap image);
}
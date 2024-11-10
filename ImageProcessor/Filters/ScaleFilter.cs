using System.Drawing;

namespace ImageProcessor.Filters;

#pragma warning disable CA1416

public class ScaleFilter : IImageFilter
{
    private readonly float _scaleFactor;

    public ScaleFilter(float scaleFactor)
    {
        _scaleFactor = scaleFactor;
    }

    public Bitmap Apply(Bitmap image)
    {
        var newSize = new Size()
        {
            Height = (int)(image.Height * _scaleFactor),
            Width = (int)(image.Width * _scaleFactor)
        };
        
        return new Bitmap(image, newSize);
    }
}
using System.Drawing;

namespace ImageProcessor.Filters;

/// <summary>
/// Represents an interface for applying image filters to a Bitmap image.
/// </summary>
public interface IImageFilter
{
    /// <summary>
    /// Applies the filter to the input image and returns the filtered image.
    /// </summary>
    /// <param name="image">The input Bitmap image to apply the filter to.</param>
    /// <returns>A new Bitmap image after applying the filter.</returns>
    Bitmap Apply(Bitmap image);
}
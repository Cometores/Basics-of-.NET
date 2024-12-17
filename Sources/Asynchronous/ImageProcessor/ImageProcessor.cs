using System.Drawing;
using System.Threading.Tasks.Dataflow;
using ImageProcessor.Filters;
using ImageProcessor.UserInterface;

namespace ImageProcessor;

#pragma warning disable CA1416

/// <summary>
/// Represents an image processing class that applies a list of filters to images.
/// </summary>
public class ImageProcessor
{
    private readonly BufferBlock<string> _filePathBuffer = new();

    /// <summary>
    /// Processes images from the specified input folder using the given filters and saves the processed images to the output folder.
    /// </summary>
    /// <param name="inputFolder">The path to the input folder containing source images.</param>
    /// <param name="outputFolder">The path to the output folder for saving processed images.</param>
    /// <param name="filters">The list of image filters to apply during processing.</param>
    /// <param name="ui">The user interface for displaying information and progress.</param>
    /// <returns>Returns a Task representing the asynchronous operation.</returns>
    public async Task ProcessImagesAsync(string inputFolder, string outputFolder, List<IImageFilter> filters,
        IUserInterface ui)
    {
        var loadImageBlock = CreateLoadImageBlock();
        var saveImageBlock = CreateSaveImageBlock(outputFolder, ui);

        LinkProcessingBlocks(loadImageBlock, saveImageBlock, filters);

        _filePathBuffer.LinkTo(loadImageBlock, new DataflowLinkOptions { PropagateCompletion = true });

        var files = Directory.GetFiles(inputFolder, "*.png").ToList();
        ui.DisplayFilesToProcess(files);

        await SendFilePathsToBuffer(files, ui);

        _filePathBuffer.Complete();
        await saveImageBlock.Completion;

        ui.ShowCompletionMessage("Image processing is complete.");
    }

    private TransformBlock<string, Bitmap> CreateLoadImageBlock() => new(filePath => new Bitmap(filePath));
    private TransformBlock<Bitmap, Bitmap> CreateFilterBlock(IImageFilter filter) => new(filter.Apply);

    private ActionBlock<Bitmap> CreateSaveImageBlock(string outputFolder, IUserInterface ui) =>
        new(image =>
        {
            string outputFilePath = Path.Combine(outputFolder, $"{Guid.NewGuid()}.jpg");
            image.Save(outputFilePath);
            image.Dispose();
            ui.ShowFileSavedMessage(outputFilePath);
        });

    private void LinkProcessingBlocks(ISourceBlock<Bitmap> loadImageBlock, ITargetBlock<Bitmap> saveImageBlock, List<IImageFilter> filters)
    {
        ISourceBlock<Bitmap> currentSourceBlock = loadImageBlock;

        foreach (var filter in filters)
        {
            var filterBlock = CreateFilterBlock(filter);
            currentSourceBlock.LinkTo(filterBlock, new DataflowLinkOptions { PropagateCompletion = true });
            currentSourceBlock = filterBlock;
        }

        currentSourceBlock.LinkTo(saveImageBlock, new DataflowLinkOptions { PropagateCompletion = true });
    }
    
    private async Task SendFilePathsToBuffer(List<string> files, IUserInterface ui)
    {
        int totalFiles = files.Count;
        int processedFiles = 0;

        foreach (var filePath in files)
        {
            await _filePathBuffer.SendAsync(filePath);
            processedFiles++;
            ui.DisplayProgress(processedFiles, totalFiles);
        }
    }
}
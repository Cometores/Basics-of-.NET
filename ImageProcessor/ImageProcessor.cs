using System.Drawing;
using System.Threading.Tasks.Dataflow;
using ImageProcessor.Filters;

namespace ImageProcessor;

#pragma warning disable CA1416

public class ImageProcessor
{
    private readonly BufferBlock<string> _filePathBuffer = new();

    public async Task ProcessImages(string inputFolder, string outputFolder, List<IImageFilter> filters, IUserInterface ui)
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

        ui.ShowCompletionMessage("Обработка изображений завершена.");
    }

    private TransformBlock<string, Bitmap> CreateLoadImageBlock()
    {
        return new TransformBlock<string, Bitmap>(filePath => new Bitmap(filePath));
    }

    private ActionBlock<Bitmap> CreateSaveImageBlock(string outputFolder, IUserInterface ui)
    {
        return new ActionBlock<Bitmap>(async image =>
        {
            string outputFilePath = Path.Combine(outputFolder, $"{Guid.NewGuid()}.jpg");
            image.Save(outputFilePath);
            image.Dispose();
            ui.ShowFileSavedMessage(outputFilePath);
        });
    }

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

    private TransformBlock<Bitmap, Bitmap> CreateFilterBlock(IImageFilter filter)
    {
        return new TransformBlock<Bitmap, Bitmap>(img => filter.Apply(img));
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
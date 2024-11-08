using System.Drawing;
using System.Threading.Tasks.Dataflow;

namespace ImageProcessor;

public class ImageProcessor
{
    private readonly BufferBlock<string> _bufferBlock = new BufferBlock<string>();

    public async Task ProcessImages(string inputFolder, string outputFolder, bool scale, bool grayscale, bool sepia)
    {
        // Список блоков для хранения последовательности обработки
        var blocks = new List<IDataflowBlock>();
        
        // Создаем необходимые блоки и добавляем их в список по порядку
        if (scale)
        {
            var scaleBlock = Transformations.CreateScaleBlock();
            _bufferBlock.LinkTo(scaleBlock, new DataflowLinkOptions { PropagateCompletion = true });
            blocks.Add(scaleBlock);
        }

        if (grayscale)
        {
            var grayscaleBlock = Transformations.CreateGrayscaleBlock();
            LinkLastBlock(blocks, grayscaleBlock);
            blocks.Add(grayscaleBlock);
        }

        if (sepia)
        {
            var sepiaBlock = Transformations.CreateSepiaBlock();
            LinkLastBlock(blocks, sepiaBlock);
            blocks.Add(sepiaBlock);
        }

        // Блок для сохранения изображений
        var saveBlock = Transformations.CreateSaveBlock(outputFolder);
        LinkLastBlock(blocks, saveBlock);

        // Передаем файлы в конвейер
        foreach (var filePath in Directory.GetFiles(inputFolder, "*.png"))
        {
            await _bufferBlock.SendAsync(filePath);
        }
        _bufferBlock.Complete();
        await saveBlock.Completion;

        Console.WriteLine("Обработка изображений завершена.");
    }

    // Вспомогательный метод для связывания блоков
    private void LinkLastBlock(List<IDataflowBlock> blocks, IDataflowBlock nextBlock)
    {
        // Если список блоков пуст, связываем с _bufferBlock
        if (blocks.Count == 0)
        {
            var target = nextBlock as ITargetBlock<string>;
            if (target != null)
                _bufferBlock.LinkTo(target, new DataflowLinkOptions { PropagateCompletion = true });
            return;
        }

        // Иначе связываем последний блок в списке с новым блоком
        var lastBlock = blocks[^1];
        if (lastBlock is ISourceBlock<Bitmap> lastBitmapSource && nextBlock is ITargetBlock<Bitmap> nextBitmapTarget)
        {
            lastBitmapSource.LinkTo(nextBitmapTarget, new DataflowLinkOptions { PropagateCompletion = true });
        }
    }
}
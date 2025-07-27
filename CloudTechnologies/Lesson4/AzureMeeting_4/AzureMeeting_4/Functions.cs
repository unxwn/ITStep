using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;

namespace AzureMeeting_4
{
    public class Functions
    {
        public static async Task ProcessQueueMessage(
            [QueueTrigger("webjobs-test")]string message,
            [Blob("big-images/{queueTrigger}", FileAccess.Read)]Stream inputFile,
            [Blob("grayscale-images/gray-{queueTrigger}", FileAccess.Write)]Stream outputFile,
            ILogger logger
            )
        {
            using(Image image = Image.Load(inputFile))
            {
                image.Mutate(x => x.Grayscale(0.8f));
                await image.SaveAsync(outputFile, new PngEncoder());
            }
            await inputFile.CopyToAsync( outputFile );

            logger.LogWarning($"File processed: {message}, Size:  {inputFile.Length} bytes");
        }
    }
}

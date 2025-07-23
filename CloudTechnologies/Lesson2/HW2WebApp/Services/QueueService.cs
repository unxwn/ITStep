using Azure.Storage.Queues;

namespace HW2WebApp.Services
{
    public class QueueService
    {
        private readonly QueueClient _queue;

        public QueueService(QueueServiceClient queueServiceClient, IConfiguration config)
        {
            string queueName = config["QueueSettings:QueueName"] ?? throw new InvalidOperationException("You should specify correct queue name!");
            
            _queue = queueServiceClient.GetQueueClient(queueName);
            _queue.CreateIfNotExists();
        }

        public Task SendMessageAsync(string message) =>
            _queue.SendMessageAsync(message);
    }
}

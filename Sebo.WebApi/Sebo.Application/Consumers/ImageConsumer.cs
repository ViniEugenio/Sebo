using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sebo.Core.Enums;
using Sebo.Core.IntegrationEvents;
using Sebo.Core.Repositories;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.Application.Consumers
{
    public class ImageConsumer : BackgroundService
    {

        private readonly IServiceProvider ServiceProvider;
        private const string Queue = "ResponseImage";
        private readonly IConnection Connection;
        private readonly IModel Channel;

        public ImageConsumer(IServiceProvider ServiceProvider)
        {

            this.ServiceProvider = ServiceProvider;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
            Channel.QueueDeclare(Queue, false, false, false, null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += async (sender, args) =>
            {

                var response = JsonConvert.DeserializeObject<ImageResponseIntegrationEvent>(Encoding.UTF8.GetString(args.Body.ToArray()));

                if (response.Success)
                {
                    await OpenChapter(response.ChapterId);
                }

                Channel.BasicAck(args.DeliveryTag, false);

            };

            Channel.BasicConsume(Queue, false, consumer);
            return Task.CompletedTask;

        }

        public async Task OpenChapter(Guid ChapterId)
        {

            using (var scope = ServiceProvider.CreateScope())
            {

                var ChapterRepository = scope.ServiceProvider.GetRequiredService<IChapterRepository>();

                var FoundedChapter = await ChapterRepository.GetById(ChapterId);
                FoundedChapter.ProcessingStatus = ChapterProcessingStatusEnum.Processed;

                await ChapterRepository.Update(FoundedChapter);

            }

        }

    }
}

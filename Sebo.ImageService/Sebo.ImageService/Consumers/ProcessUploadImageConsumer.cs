using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sebo.ImageService.Models;
using Sebo.ImageService.Services;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sebo.ImageService.Consumers
{
    public class ProcessUploadImageConsumer : BackgroundService
    {

        private const string Queue = "Images";
        private const string ResponseQueue = "ResponseImage";
        private readonly IConnection Connection;
        private readonly IModel Channel;
        private readonly IServiceProvider ServiceProvider;

        public ProcessUploadImageConsumer(IServiceProvider ServiceProvider)
        {

            this.ServiceProvider = ServiceProvider;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
            Channel.QueueDeclare(Queue, false, false, false, null);
            Channel.QueueDeclare(ResponseQueue, false, false, false, null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += async (sender, args) =>
            {

                var ChapterFilesFormated = JsonConvert.DeserializeObject<ChapterFilesIntegrationEvent>(Encoding.UTF8.GetString(args.Body.ToArray()));

                var response = await ProcessImage(ChapterFilesFormated);

                string ResponseJson = JsonConvert.SerializeObject(new ChapterFilesResponseIntegrationEvent(response, ChapterFilesFormated.ChapterId, response ?
                    "Arquivos do capítulo cadastrados com sucesso" : "Não foi possível cadastrar os arquivos tente novamente mais tarde"));

                Channel.BasicPublish("", ResponseQueue, null, Encoding.UTF8.GetBytes(ResponseJson));

                Channel.BasicAck(args.DeliveryTag, false);

            };

            Channel.BasicConsume(Queue, false, consumer);
            return Task.CompletedTask;

        }

        public async Task<bool> ProcessImage(ChapterFilesIntegrationEvent ChapterFiles)
        {

            using (var scope = ServiceProvider.CreateScope())
            {

                var ImageService = scope.ServiceProvider.GetRequiredService<IImageService>();
                return await ImageService.UploadImage(ChapterFiles);

            }

        }

    }
}

using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using Sebo.Core.Services;

namespace Sebo.Infrastructure.MicroServices.MessageBus
{
    public class MessageBusService : IMessageBusService
    {

        private readonly ConnectionFactory Factory;

        public MessageBusService(IConfiguration Configuration)
        {

            Factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

        }

        public void Publish(string queue, byte[] message)
        {

            using (var connection = Factory.CreateConnection())
            {

                using (var channel = connection.CreateModel())
                {

                    channel.QueueDeclare(queue, false, false, false, null);
                    channel.BasicPublish("", queue, null, message);

                }

            }

        }
    }
}

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Handler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConnectRabbit();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ConnectRabbit()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Password = "schin123", UserName = "schin" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                };
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

            }
        }

        // Tarefas:
        // TODO: Subir um rabbit local
        // TODO: Criar handler no formato async
        // TODO: Criar uma camada de comunicação com o Rabbit
        // TODO: No inserir/Atualizar da API, mandar para a fila, para o handler processar
        // TODO: Estudar ExchangeTypes de fila
        // TODO: Estudar o porquê criar retry/dead
        // https://www.rabbitmq.com/getstarted.html
        // https://hub.docker.com/_/rabbitmq
        // https://docs.docker.com/desktop/install/windows-install/
    }
}

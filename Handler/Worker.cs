using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuracao;
        //private readonly IRabbitService _rabbitService;
        //private readonly IVeiculoHandler _veiculoHandler;

        //public Worker(ILogger<Worker> logger, IConfiguration configuracao, IRabbitService rabbitService, IVeiculoHandler veiculoHandler)
        public Worker(ILogger<Worker> logger, IConfiguration configuracao)
        {
            _logger = logger;
            _configuracao = configuracao;
            //_rabbitService = rabbitService;
            //_veiculoHandler = veiculoHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuracao.GetSection("RabbitMQConfiguration:HostName").Value,
                Password = _configuracao.GetSection("RabbitMQConfiguration:Password").Value,
                UserName = _configuracao.GetSection("RabbitMQConfiguration:UserName").Value
            }; ;

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

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

                _logger.LogInformation("Mensagem recebida: {message}", message);
            };

            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        // Tarefas:
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

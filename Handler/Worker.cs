using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
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

using GISA.ChangeDataCapture.Worker.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GISA.ChangeDataCapture.Worker.Kafka
{
    public class KafkaGisaPortalConsumerWorker : BackgroundService
    {
        private readonly IChangeDataCaptureConsumerManager _changeDataCaptureConsumerManager;
        private readonly ILogger<KafkaGisaPortalConsumerWorker> _logger;

        public KafkaGisaPortalConsumerWorker(ILogger<KafkaGisaPortalConsumerWorker> logger, IChangeDataCaptureConsumerManager changeDataCaptureConsumerManager)
        {
            _logger = logger;
            _changeDataCaptureConsumerManager = changeDataCaptureConsumerManager;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _changeDataCaptureConsumerManager.StartConsumer(cancellationToken);

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000, cancellationToken);
            }
        }
    }
}

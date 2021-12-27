using GISA.ChangeDataCapture.Worker.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace GISA.ChangeDataCapture.Worker.Kafka
{
    internal class KafkaGisaPortalConsumerManager : IChangeDataCaptureConsumerManager
    {
        private readonly IServiceProvider _serviceProvider;

        public KafkaGisaPortalConsumerManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void StartConsumer(CancellationToken cancellationToken)
        {
                var kafkaTopicMessageConsumer = _serviceProvider.GetRequiredService<IChangeDataCaptureConsumer>();
                new Thread(() => kafkaTopicMessageConsumer.Subscribe(cancellationToken)).Start();
        }
    }
}

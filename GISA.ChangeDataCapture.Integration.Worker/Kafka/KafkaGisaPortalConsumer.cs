using Confluent.Kafka;
using GISA.ChangeDataCapture.Worker.Contracts;
using GISA.ChangeDataCapture.Worker.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GISA.ChangeDataCapture.Worker.Kafka
{
    internal class KafkaGisaPortalConsumer : IChangeDataCaptureConsumer
    {
        private readonly IChangeDataCaptureConsumerBuilder _kafkaConsumerBuilder;
        private readonly IChangeDataCaptureSubject _changeDataCaptureSubject;
        private readonly KafkaMessageRoot _kafkaMessageRoot;
        private readonly ILogger<KafkaGisaPortalConsumer> _logger;

        public KafkaGisaPortalConsumer(ILogger<KafkaGisaPortalConsumer> logger,
            IChangeDataCaptureConsumerBuilder kafkaConsumerBuilder,
            IChangeDataCaptureDeserializeBuilder kafkaDeserializeBuilder,
            IChangeDataCaptureSubject changeDataCaptureSubject)
        {
            _logger = logger;
            _kafkaConsumerBuilder = kafkaConsumerBuilder;
            _changeDataCaptureSubject = changeDataCaptureSubject;
            _kafkaMessageRoot = kafkaDeserializeBuilder.Build();
        }

        public void Subscribe(CancellationToken cancellationToken)
        {
            using (var consumer = _kafkaConsumerBuilder.Build())
            {
                _logger.LogInformation($"Starting consumer for {_kafkaConsumerBuilder.GetTopicName()}");

                consumer.Subscribe(_kafkaConsumerBuilder.GetTopicName());

                try
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var consumeResult = consumer.Consume(cancellationToken);

                        JsonConvert.PopulateObject(consumeResult.Message.Value, _kafkaMessageRoot);
                        _changeDataCaptureSubject.Notify(_kafkaMessageRoot);
                        consumer.Commit(consumeResult);
                        _logger.LogInformation($"{consumeResult.Message.Value}");
                        Task.Delay(2000);
                    }
                }
                catch (OperationCanceledException exception)
                {
                    _logger.LogError($"OperationCanceledException {_kafkaConsumerBuilder.GetTopicName()} {exception.Message} {exception.InnerException?.Message}");
                }
                catch (ConsumeException exception)
                {
                    _logger.LogError($"ConsumeException {_kafkaConsumerBuilder.GetTopicName()} {exception.Message} {exception.InnerException?.Message}");
                }
                finally
                {
                    consumer.Close();
                    consumer.Dispose();
                }
            }
        }
    }
}

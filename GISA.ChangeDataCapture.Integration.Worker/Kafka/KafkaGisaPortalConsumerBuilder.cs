using Confluent.Kafka;
using GISA.ChangeDataCapture.Worker.Configuration;
using GISA.ChangeDataCapture.Worker.Contracts;
using GISA.ChangeDataCapture.Worker.Models;
using System;
using System.Collections.Generic;

namespace GISA.ChangeDataCapture.Worker.Kafka
{
    internal class KafkaGisaPortalConsumerBuilder : IChangeDataCaptureConsumerBuilder
    {
        private readonly KafkaOptions _kafkaOptions;
        private readonly KeyValuePair<string, ConsumerConfig> _kafkaConsumerConfiguration;

        public KafkaGisaPortalConsumerBuilder(KafkaOptions kafkaOptions)
        {
            _kafkaOptions = kafkaOptions
                            ?? throw new ArgumentNullException(nameof(kafkaOptions));
            _kafkaConsumerConfiguration = new KafkaConfiguration(_kafkaOptions).ToKafkaConsumerConfig();
        }

        public IConsumer<string, string> Build()
        {            
            var consumerBuilder = new ConsumerBuilder<string, string>(_kafkaConsumerConfiguration.Value);
            return consumerBuilder.Build();
        }

        public string GetTopicName()
        {
            return _kafkaConsumerConfiguration.Key;
        }
    }
}

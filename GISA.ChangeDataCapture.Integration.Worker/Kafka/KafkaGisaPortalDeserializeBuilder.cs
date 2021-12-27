using GISA.ChangeDataCapture.Worker.Configuration;
using GISA.ChangeDataCapture.Worker.Contracts;
using GISA.ChangeDataCapture.Worker.Models;
using System;

namespace GISA.ChangeDataCapture.Worker.Kafka
{
    internal class KafkaGisaPortalDeserializeBuilder : IChangeDataCaptureDeserializeBuilder
    {
        private readonly KafkaOptions _kafkaOptions;
        private readonly KafkaDeserializeConfiguration _kafkaDeserializeConfiguration;

        public KafkaGisaPortalDeserializeBuilder(KafkaOptions kafkaOptions)
        {
            _kafkaOptions = kafkaOptions ?? throw new ArgumentNullException(nameof(kafkaOptions));
            _kafkaDeserializeConfiguration = new KafkaDeserializeConfiguration(_kafkaOptions);
        }

        public KafkaMessageRoot Build()
        {
            return _kafkaDeserializeConfiguration.ToKafkaMessageRoot();
        }
    }
}

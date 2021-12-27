using Confluent.Kafka;
using GISA.ChangeDataCapture.Worker.Models;
using System.Collections.Generic;

namespace GISA.ChangeDataCapture.Worker.Configuration
{
    internal class KafkaConfiguration
    {
        public string TopicName { get; private set; }
        public string BootstrapServers { get; private set; }
        public string KafkaGroupId { get; private set; }

        public KafkaConfiguration(KafkaOptions kafkaOptions)
        {
            TopicName = kafkaOptions.TopicName;
            KafkaGroupId = kafkaOptions.KafkaGroupId;
            BootstrapServers = kafkaOptions.KafkaBootstrapServers;
        }

        public KeyValuePair<string, ConsumerConfig> ToKafkaConsumerConfig()
        {
            return new KeyValuePair<string, ConsumerConfig>(TopicName, new ConsumerConfig
            {
                BootstrapServers = BootstrapServers,
                GroupId = KafkaGroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            });
        }
    }
}

using System;

namespace GISA.ChangeDataCapture.Worker.Models
{
    public class KafkaOptions
    {
        public string KafkaBootstrapServers { get; set; }
        public string KafkaGroupId { get; set; }
        public string TopicName { get; set; }
        public Type MapperTo { get; set; }
    }
}

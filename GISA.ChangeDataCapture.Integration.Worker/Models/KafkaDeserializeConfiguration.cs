using GISA.ChangeDataCapture.Worker.Models;

namespace GISA.ChangeDataCapture.Worker.Configuration
{
    internal class KafkaDeserializeConfiguration
    {
        private readonly KafkaOptions _kafkaOptions;

        public KafkaDeserializeConfiguration(KafkaOptions kafkaOptions)
        {
            _kafkaOptions = kafkaOptions;
        }

        public KafkaMessageRoot ToKafkaMessageRoot()
        {
            return new KafkaMessageRoot(_kafkaOptions.MapperTo);
        }
    }
}

using Confluent.Kafka;

namespace GISA.ChangeDataCapture.Worker.Contracts
{
    internal interface IChangeDataCaptureConsumerBuilder
    {
        string GetTopicName();
        IConsumer<string, string> Build();
    }
}

using GISA.ChangeDataCapture.Worker.Models;

namespace GISA.ChangeDataCapture.Worker.Contracts
{
    internal interface IChangeDataCaptureDeserializeBuilder
    {
        KafkaMessageRoot Build();
    }
}

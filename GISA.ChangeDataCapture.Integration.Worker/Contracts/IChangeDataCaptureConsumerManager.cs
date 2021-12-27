using System.Threading;

namespace GISA.ChangeDataCapture.Worker.Contracts
{
    public interface IChangeDataCaptureConsumerManager
    {
        void StartConsumer(CancellationToken cancellationToken);
    }
}

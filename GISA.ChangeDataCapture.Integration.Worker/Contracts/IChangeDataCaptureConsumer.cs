using System.Threading;

namespace GISA.ChangeDataCapture.Worker.Contracts
{
    internal interface IChangeDataCaptureConsumer
    {
        void Subscribe(CancellationToken cancellationToken);
    }
}

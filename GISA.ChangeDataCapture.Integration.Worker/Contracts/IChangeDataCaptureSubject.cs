namespace GISA.ChangeDataCapture.Worker.Contracts
{
    public interface IChangeDataCaptureSubject
    {
        void Attach(IChangeDataCaptureObserver observer);
        void Detach(IChangeDataCaptureObserver observer);
        void Notify<T>(T notification);
    }
}

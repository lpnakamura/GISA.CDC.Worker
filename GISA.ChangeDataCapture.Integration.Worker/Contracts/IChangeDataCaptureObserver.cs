namespace GISA.ChangeDataCapture.Worker.Contracts
{
    public interface IChangeDataCaptureObserver
    {
        void Update<T>(T notification);
    }
}

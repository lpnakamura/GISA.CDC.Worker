using GISA.ChangeDataCapture.Worker.Contracts;
using System.Collections.Generic;

namespace GISA.ChangeDataCapture.Worker.Kafka
{
    internal class KafkaGisaPortalSubject : IChangeDataCaptureSubject
    {
        private readonly List<IChangeDataCaptureObserver> _observers;
        public KafkaGisaPortalSubject()
        {
            _observers = new List<IChangeDataCaptureObserver>();
        }

        public void Attach(IChangeDataCaptureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IChangeDataCaptureObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify<T>(T notification)
        {
            foreach (var observer in _observers)
                observer.Update(notification);           
        }
    }
}

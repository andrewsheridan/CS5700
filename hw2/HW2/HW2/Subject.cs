using System.Collections.Generic;

namespace StockMonitor
{
    public class Subject
    {
        private readonly object _myLock = new object();
        private readonly List<StockObserver> _subscribers = new List<StockObserver>();

        public List<StockObserver> Subscribers { get { return _subscribers; } }

        public void Subscribe(StockObserver observer)
        {
            lock (_myLock)
            {
                if (observer != null && !_subscribers.Contains(observer))
                    _subscribers.Add(observer);
            }
        }

        public void Unsubscribe(StockObserver observer)
        {
            lock (_myLock)
            {
                if (_subscribers.Contains(observer))
                    _subscribers.Remove(observer);
            }
        }

        //public void Notify()
        //{
        //    lock (_myLock)
        //    {
        //        foreach (StockObserver observer in _subscribers)
        //            observer.Update(Clone());
        //    }
        //}

        public void Notify()
        {
            lock (_myLock)
            {
                foreach (StockObserver observer in _subscribers)
                    observer.Update();
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }

        public int GetSubscriberCount()
        {
            return Subscribers.Count;
        }
    }
}

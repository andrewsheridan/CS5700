using System.Collections.Generic;

namespace SudokuSolver
{
    public class Subject
    {
        private readonly object _myLock = new object();
        private readonly List<Unit> _subscribers = new List<Unit>();

        public List<Unit> Subscribers { get { return _subscribers; } }

        public void Subscribe(Unit observer)
        {
            lock (_myLock)
            {
                if (observer != null && !_subscribers.Contains(observer))
                    _subscribers.Add(observer);
            }
        }

        public void Unsubscribe(Unit observer)
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
        //        foreach (Unit observer in _subscribers)
        //            observer.Update(Clone());
        //    }
        //}

        public void Notify(char updatedValue)
        {
            lock (_myLock)
            {
                foreach (Unit observer in _subscribers)
                    observer.RemovePossibleValueFromCells(updatedValue);
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

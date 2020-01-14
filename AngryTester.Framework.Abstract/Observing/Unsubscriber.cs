namespace AngryTester.Framework.Abstract.Observing
{
    using System;
    using System.Collections.Generic;

    internal class Unsubscriber<T> : IDisposable
    {
        private readonly IObserver<T> observer;

        private readonly List<IObserver<T>> observers;

        internal Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}

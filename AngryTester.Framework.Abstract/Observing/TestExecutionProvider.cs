namespace AngryTester.Framework.Abstract.Observing
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class TestExecutionProvider<TContext> : ITestExecutionProvider<TContext>
        where TContext : class
    {
        private readonly List<IObserver<ExecutionStatus<TContext>>> _observers;

        public TestExecutionProvider()
        {
            _observers = new List<IObserver<ExecutionStatus<TContext>>>();
        }

        public void AfterCleanUp(TContext context, MemberInfo memberInfo)
        {
            NotifyObservers(context, memberInfo, ExecutionPhase.AfterCleanUp);
        }

        public void AfterInitialize(TContext context, MemberInfo memberInfo)
        {
            NotifyObservers(context, memberInfo, ExecutionPhase.AfterInitialize);
        }

        public void BeforeCleanUp(TContext context, MemberInfo memberInfo)
        {
            NotifyObservers(context, memberInfo, ExecutionPhase.BeforeCleanUp);
        }

        public void BeforeInitialize(TContext context, MemberInfo memberInfo)
        {
            NotifyObservers(context, memberInfo, ExecutionPhase.BeforeInitialize);
        }

        public void Dispose() => _observers.ForEach(observer => observer.OnCompleted());

        public IDisposable Subscribe(IObserver<ExecutionStatus<TContext>> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber<ExecutionStatus<TContext>>(_observers, observer);
        }

        private void NotifyObservers(TContext context, MemberInfo memberInfo, ExecutionPhase phase)
        {
            foreach (var currentObserver in _observers)
            {
                currentObserver.OnNext(new ExecutionStatus<TContext>(context, memberInfo, phase));
            }
        }
    }
}

namespace AngryTester.Framework.Abstract.Observing
{
    using System;
    using System.Reflection;

    public class DefaultTestBehaviorObserver<TContext> : IObserver<ExecutionStatus<TContext>>
        where TContext : class
    {
        public virtual void Subscribe(IObservable<ExecutionStatus<TContext>> provider) { }

        public virtual void OnCompleted() { }

        public virtual void OnError(Exception error) { throw error; }

        public void OnNext(ExecutionStatus<TContext> value)
        {
            switch (value.Phase)
            {
                case ExecutionPhase.BeforeInitialize:
                    BeforeInitialize(value.TestContext, value.MemberInfo);
                    break;
                case ExecutionPhase.AfterInitialize:
                    AfterInitialize(value.TestContext, value.MemberInfo);
                    break;
                case ExecutionPhase.BeforeCleanUp:
                    BeforeCleanUp(value.TestContext, value.MemberInfo);
                    break;
                case ExecutionPhase.AfterCleanUp:
                    AfterCleanUp(value.TestContext, value.MemberInfo);
                    break;
                default:
                    break;
            }
        }

        protected virtual void BeforeInitialize(TContext context, MemberInfo memberInfo) { }

        protected virtual void AfterInitialize(TContext context, MemberInfo memberInfo) { }

        protected virtual void BeforeCleanUp(TContext context, MemberInfo memberInfo) { }

        protected virtual void AfterCleanUp(TContext context, MemberInfo memberInfo) { }
    }
}

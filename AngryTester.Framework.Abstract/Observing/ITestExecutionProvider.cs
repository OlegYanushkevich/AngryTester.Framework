namespace AngryTester.Framework.Abstract.Observing
{
    using System;
    using System.Reflection;

    public interface ITestExecutionProvider<TContext> : IObservable<ExecutionStatus<TContext>>, IDisposable
        where TContext : class
    {
        void BeforeInitialize(TContext context, MemberInfo memberInfo);

        void AfterInitialize(TContext context, MemberInfo memberInfo);

        void BeforeCleanUp(TContext context, MemberInfo memberInfo);

        void AfterCleanUp(TContext context, MemberInfo memberInfo);
    }
}

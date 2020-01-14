using AngryTester.Framework.Abstract.Observing;
using Autofac;
using System.Reflection;
using System.Threading;

namespace AngryTester.Framework.Abstract
{
    public abstract class BaseFixture<TContext> : IHasLifetimeScope
        where TContext : class
    {
        private readonly ThreadLocal<ILifetimeScope> threadLocalLifetimeScope = new ThreadLocal<ILifetimeScope>();

        public abstract TContext Context { get; }

        public ILifetimeScope Resolver
        {
            get => threadLocalLifetimeScope.Value;
            set => threadLocalLifetimeScope.Value = value;
        }

        public virtual void Initialize()
        {
            Resolver = GetResolver().BeginLifetimeScope(InitializeResolver);
            var observable = Resolver.Resolve<ITestExecutionProvider<TContext>>();

            InitializeObservers(observable);
            var memberInfo = GetCurrentExecutionMemberInfo();

            observable.BeforeInitialize(Context, memberInfo);
            BeforeTest();
            observable.AfterInitialize(Context, memberInfo);
        }

        public virtual void CleanUp()
        {
            var memberInfo = GetCurrentExecutionMemberInfo();
            var observable = Resolver.Resolve<ITestExecutionProvider<TContext>>();

            observable.BeforeCleanUp(Context, memberInfo);
            AfterTest();
            observable.AfterCleanUp(Context, memberInfo);
        }

        protected virtual void BeforeTest() { }

        protected virtual void AfterTest() { }

        protected virtual void InitializeObservers(ITestExecutionProvider<TContext> observable) { }

        protected virtual void InitializeResolver(ContainerBuilder builder) { }

        protected abstract MemberInfo GetCurrentExecutionMemberInfo();

        protected abstract ILifetimeScope GetResolver();
    }
}

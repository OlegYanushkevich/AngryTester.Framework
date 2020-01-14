using Autofac;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace AngryTester.Framework.Abstract.NUnit3
{
    public abstract class BaseFixture : BaseFixture<TestExecutionContext>
    {
        public override TestExecutionContext Context => TestExecutionContext.CurrentContext;

        protected override ILifetimeScope GetResolver()
        {
            return GetParentResolverOrDefault() ?? DependencyResolver.GetResolver();
        }

        private ILifetimeScope GetParentResolverOrDefault()
        {
            bool found = false;
            ITest current = Context.CurrentTest;

            while (current.HasParent())
            {
                current = current.Parent;

                if (current.IsSetUpFixture())
                {
                    found = true;
                    break;
                }
            }

            return found ? (current.Fixture as IHasLifetimeScope).Resolver : null;
        }
    }
}

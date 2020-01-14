using Autofac;

namespace AngryTester.Framework.Abstract
{
    public interface IHasLifetimeScope
    {
        ILifetimeScope Resolver { get; }
    }
}

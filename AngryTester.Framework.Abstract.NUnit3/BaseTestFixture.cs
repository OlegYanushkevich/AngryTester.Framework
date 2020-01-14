using NUnit.Framework;
using System.Reflection;

namespace AngryTester.Framework.Abstract.NUnit3
{
    public abstract class BaseTestFixture : BaseFixture
    {
        [SetUp]
        public sealed override void Initialize()
        {
            base.Initialize();
        }

        [TearDown]
        public sealed override void CleanUp()
        {
            base.CleanUp();
        }

        protected override MemberInfo GetCurrentExecutionMemberInfo()
        {
            return GetType().GetMethod(Context.CurrentTest.MethodName);
        }
    }
}

using NUnit.Framework;
using System.Reflection;

namespace AngryTester.Framework.Abstract.NUnit3
{
    public class BaseSetUpFixture : BaseFixture
    {
        [OneTimeSetUp]
        public sealed override void Initialize()
        {
            base.Initialize();
        }

        [OneTimeTearDown]
        public sealed override void CleanUp()
        {
            base.CleanUp();
        }

        protected override MemberInfo GetCurrentExecutionMemberInfo()
        {
            return GetType();
        }
    }
}

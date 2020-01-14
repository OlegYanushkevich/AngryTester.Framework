using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace AngryTester.Framework.Abstract.NUnit3
{
    public static class NUnit3Extensions
    {
        private const string SetUpFixture = "SetUpFixture";

        public static bool IsSetUpFixture(this ITest test) => SetUpFixture.Equals(test.TestType);

        public static bool HasParent(this ITest test) => test.Parent != null;
    }
}

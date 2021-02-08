using NUnit.Framework;
using Xamarin.UITest;

namespace MVVMStarter.UITests.Tests
{
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void Repl()
        {
            if (TestEnvironment.IsTestCloud)
                Assert.Ignore("Local only");

            app.Repl();
        }
    }
}

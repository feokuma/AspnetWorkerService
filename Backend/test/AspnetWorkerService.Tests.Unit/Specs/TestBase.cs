using Autofac.Extras.FakeItEasy;
using NUnit.Framework;

namespace AspnetWorkerService.Tests.Unit
{
    public class TestBase
    {
        protected AutoFake _autoFake;

        [SetUp]
        public void Setup()
        {
            _autoFake = new AutoFake();
        }
    }
}
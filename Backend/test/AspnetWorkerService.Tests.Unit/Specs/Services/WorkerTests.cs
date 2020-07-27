using System;
using System.Threading;
using System.Threading.Tasks;
using AspnetWorkerService.Infrastructure;
using AspnetWorkerService.Services;
using FakeItEasy;
using NUnit.Framework;

namespace AspnetWorkerService.Tests.Unit.Specs.Services
{
    public class WorkerTests : TestBase
    {
        [Test]
        public async Task StartAsyncShouldCallLoggerAdapterInformation()
        {
            var workerService = _autoFake.Resolve<Worker>();
            var cancellationToken = new CancellationToken();

            await workerService.StartAsync(cancellationToken);

            A.CallTo(() => _autoFake.Resolve<ILoggerAdapter<Worker>>()
                .LogInformation("AspnetWorkerService started", A<object[]>.Ignored))
                .MustHaveHappenedOnceExactly();
        }
    }
}

using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;
using AspnetWorkerService.Services;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AspnetWorkerService.Tests.Unit.Specs.Services
{
    public class WorkerTests : TestBase
    {
        [Test]
        public async Task StartAsyncShouldCallLoggerAdapterInformation()
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            var workerService = _autoFake.Resolve<Worker>();
            var cancellationToken = new CancellationToken();

            await workerService.StartAsync(cancellationToken);

            A.CallTo(() => _autoFake.Resolve<ILogger<Worker>>()
                .LogInformation("AspnetWorkerService started", A<object[]>.Ignored))
                .MustHaveHappenedOnceExactly();
        }
    }
}

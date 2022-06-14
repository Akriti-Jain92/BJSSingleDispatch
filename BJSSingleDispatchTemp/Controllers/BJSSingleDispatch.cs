using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.ResourceStack.Common.BackgroundJobs;

namespace BJSSingleDispatchTemp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BJSSingleDispatch : ControllerBase
    {

        private readonly ILogger<BJSSingleDispatch> _logger;

        public BJSSingleDispatch(ILogger<BJSSingleDispatch> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<String> Get()
        {
            Console.WriteLine("I am for testing");
            System.Diagnostics.Debug.WriteLine("I am for testing");
            var jobmetadata = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback5min")
            };

            var jobBuilder1 = JobBuilder.Create(jobPartition: "5min", jobId: "id5min")
              .WithCallback(typeof(CommonCallback))
              .WithRepeatStrategy(3, TimeSpan.FromMinutes(5))
              .WithMetadata(jobmetadata)
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata2 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback10min")
            };

            var jobBuilder2 = JobBuilder.Create(jobPartition: "10min", jobId: "id10min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata2)
              .WithRepeatStrategy(2, TimeSpan.FromMinutes(10))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata3 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback7min")
            };

            var jobBuilder3 = JobBuilder.Create(jobPartition: "7min", jobId: "id7min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata3)
              .WithRepeatStrategy(100, TimeSpan.FromMinutes(7))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata4 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback12min")
            };

            var jobBuilder4 = JobBuilder.Create(jobPartition: "12min", jobId: "id12min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata4)
              .WithRepeatStrategy(150, TimeSpan.FromMinutes(12))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata5 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback15min")
            };

            var jobBuilder5 = JobBuilder.Create(jobPartition: "15min", jobId: "id15min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata5)
              .WithRepeatStrategy(15, TimeSpan.FromMinutes(15))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata6 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback18min")
            };

            var jobBuilder6 = JobBuilder.Create(jobPartition: "18min", jobId: "id18min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata6)
              .WithRepeatStrategy(50, TimeSpan.FromMinutes(18))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata7 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback20min")
            };

            var jobBuilder7 = JobBuilder.Create(jobPartition: "20min", jobId: "id20min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata7)
              .WithRepeatStrategy(20, TimeSpan.FromMinutes(20))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var jobmetadata8 = new JobMetadata
            {
                Callback = String.Format("BJSSingleDispatchTemp.Controllers.JobCallback25min")
            };

            var jobBuilder8 = JobBuilder.Create(jobPartition: "25min", jobId: "id25min")
              .WithCallback(typeof(CommonCallback))
              .WithMetadata(jobmetadata8)
              .WithRepeatStrategy(25, TimeSpan.FromMinutes(25))
              .WithRetryStrategy(2, TimeSpan.FromMinutes(1));

            var managementClient1 = new JobManagementClient(
              connectionString: String.Format("DefaultEndpointsProtocol=https;AccountName=akritibjsaffinitytest;AccountKey=Fw139zYBUq2mgL/z5y5D1+1mmo055ilXZZbmXrECUmFKFe2j76F3dRW10ilqWgfs0ymd1lpQtA7w+AStpMC3mw==;EndpointSuffix=core.windows.net"),
              executionAffinity: string.Empty,
              eventSource: new EventSourceTest(),
              encryptionUtility: null);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder1)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder2)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder3)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder4)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder5)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder6)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder7)
              .ConfigureAwait(continueOnCapturedContext: false);

            await managementClient1
              .CreateOrUpdateJob(jobBuilder8)
              .ConfigureAwait(continueOnCapturedContext: false);

            var dispatcherClient1 = new JobDispatcherClient(
              connectionString: String.Format("DefaultEndpointsProtocol=https;AccountName=akritibjsaffinitytest;AccountKey=Fw139zYBUq2mgL/z5y5D1+1mmo055ilXZZbmXrECUmFKFe2j76F3dRW10ilqWgfs0ymd1lpQtA7w+AStpMC3mw==;EndpointSuffix=core.windows.net"),
              executionAffinity: string.Empty,
              eventSource: new EventSourceTest(),
              encryptionUtility: null);

            dispatcherClient1.RegisterJobCallback(typeof(CommonCallback));

            dispatcherClient1.ProvisionSystemConsistencyJob().Wait();

            dispatcherClient1.Start();

            return "BJS Execution: " + new DateTime();
        }
    }
}
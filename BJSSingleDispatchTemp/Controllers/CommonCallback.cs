using Microsoft.WindowsAzure.ResourceStack.Common.BackgroundJobs;

namespace BJSSingleDispatchTemp.Controllers
{
    [JobCallback(Name = "CommonCallback")]
    public class CommonCallback : BackgroundRuntimeJobCallback<JobMetadata>
    {
        protected override Task<JobExecutionResult> OnExecute()
        {
            return base.OnExecute();
        }
    }
}

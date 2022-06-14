using Microsoft.WindowsAzure.ResourceStack.Common.BackgroundJobs;
using System.Reflection;

namespace BJSSingleDispatchTemp.Controllers
{

    public class BackgroundRuntimeJobCallback<TMetadata> : JobCallback<TMetadata>
        where TMetadata : JobMetadata
    {
        protected override Task<JobExecutionResult> OnExecute()
        {
            string call = this.Metadata.Callback ?? "JobCallback5min";
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.FullName == call);
            Object obj = Activator.CreateInstance(type: type);
            MethodInfo methodInfo = type.GetMethod("ExecuteAsync");
            methodInfo.Invoke(obj, null);
            return Task.FromResult(new JobExecutionResult { Status = JobExecutionStatus.Succeeded });
        }
    }
}

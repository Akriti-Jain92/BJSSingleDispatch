using Microsoft.WindowsAzure.ResourceStack.Common.BackgroundJobs;

namespace BJSSingleDispatchTemp.Controllers
{
    //[JobCallback(Name = "JobCallback10min")]
    public class JobCallback10min
    {
        public async Task<JobExecutionResult> ExecuteAsync()
        {
            Console.WriteLine("I am CallBack for 10 mins: " + DateTime.Now);
            System.Diagnostics.Debug.WriteLine("I am CallBack for 10 mins: " + DateTime.Now);
            string fullPath = String.Format("C:\\Users\\akritijain\\Desktop\\OutputSameStorage1\\10min.txt");
            using (StreamWriter writer = File.AppendText(fullPath))
            {
                writer.WriteLine("I am CallBack for 10 mins: " + DateTime.Now);
            }

            return await Task.FromResult(new JobExecutionResult { Status = JobExecutionStatus.Succeeded });
        }
    }
}

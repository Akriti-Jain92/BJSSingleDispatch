using Newtonsoft.Json;

namespace BJSSingleDispatchTemp.Controllers
{
    public class JobMetadata
    {
        public string JobCallbackType = "ScheduledTriggerJobCallback";

        public string? Callback { get; set; }

    }
}

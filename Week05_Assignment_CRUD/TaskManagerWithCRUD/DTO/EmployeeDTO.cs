using Newtonsoft.Json;

namespace TaskManagerWithCRUD.DTO
{
    public class EmployeeDTO
    {
        [JsonProperty(PropertyName = "taskName", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get; set; }

        [JsonProperty(PropertyName = "taskDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskDescription { get; set; }
        public string UId { get; internal set; }
    }
}

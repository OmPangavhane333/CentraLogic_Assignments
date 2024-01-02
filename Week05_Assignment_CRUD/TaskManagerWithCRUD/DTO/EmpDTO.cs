using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TaskManagerWithCRUD.DTO
{
    public class EmpDTO
    {
        [JsonProperty(PropertyName = "taskName", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskName { get; set; }

        [JsonProperty(PropertyName = "taskDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskDescription { get; set; }

        [JsonProperty(PropertyName = "taskUId", NullValueHandling = NullValueHandling.Ignore)]
        public string TaskUId { get; set; }
    }
} 

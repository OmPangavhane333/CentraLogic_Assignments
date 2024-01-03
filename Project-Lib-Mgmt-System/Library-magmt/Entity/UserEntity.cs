using Newtonsoft.Json;

namespace Library_magmt.Entity
{
    public class Base 
    {
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "archieved", NullValueHandling = NullValueHandling.Ignore)]
        public bool Archieved { get; set; }

        [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "updateBy", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdateBy { get; set; }


        [JsonProperty(PropertyName = "updateByName", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdateByName { get; set; }

        [JsonProperty(PropertyName = "updateOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdateOn { get; set; }

        [JsonProperty(PropertyName = "createdBy", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedBy { get; set; }


        [JsonProperty(PropertyName = "documentType", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "createdByName", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [JsonProperty(PropertyName = "createdOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedOn { get; set; }
    }
    public class Users : Base
    {
        [JsonProperty(PropertyName = "UId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "UserName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "UserPassword", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPassword { get; set; }

        [JsonProperty(PropertyName = "ConfirmPass", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfirmPassword { get; set; }

        [JsonProperty(PropertyName = "UserPrnNo", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPrnNo { get; set; }

        [JsonProperty(PropertyName = "UserAge", NullValueHandling = NullValueHandling.Ignore)]
        public int UserAge { get; set; }

        [JsonProperty(PropertyName = "FullName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserFullname { get; set; }

    }
}

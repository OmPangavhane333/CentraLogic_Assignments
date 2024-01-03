using Newtonsoft.Json;

namespace Library_magmt.DTO
{
    public class UserSignUpDTO
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "UserName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "UserPassword", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPassword { get; set; }

        [JsonProperty(PropertyName = "ConfirmPass", NullValueHandling = NullValueHandling.Ignore)]
        public string ConfirmPassword { get; set; }

        [JsonProperty(PropertyName = "FullName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserFullname { get; set; }

        [JsonProperty(PropertyName = "UserPrnNo", NullValueHandling = NullValueHandling.Ignore)]
        public string UserPrnNo { get; set; }

        [JsonProperty(PropertyName = "UserAge", NullValueHandling = NullValueHandling.Ignore)]
        public int UserAge { get; set; }

    }
}

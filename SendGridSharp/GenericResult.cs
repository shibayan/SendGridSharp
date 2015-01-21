using Newtonsoft.Json;

namespace SendGridSharp
{
    internal class GenericResult
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccess
        {
            get { return Message == SuccessMessage; }
        }

        private const string SuccessMessage = "success";
    }
}

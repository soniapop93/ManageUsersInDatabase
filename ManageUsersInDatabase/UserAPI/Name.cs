using System.Text.Json.Serialization;

namespace ManageUsersInDatabase.UserAPI
{
    public class Name
    {
        public string title { get; set; }

        [JsonPropertyName("first")]
        public string firstName { get; set; }

        [JsonPropertyName("last")]
        public string lastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

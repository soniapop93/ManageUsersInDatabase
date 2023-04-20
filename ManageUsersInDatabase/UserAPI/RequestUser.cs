using ManageUsersInDatabase.Utilities;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ManageUsersInDatabase.UserAPI
{
    public class RequestUser
    {
        public string getNewUserFromAPI(string endpoint)
        {
            return RequestManager.getRequest(endpoint);
        }

        public User parseInfoUser(string response)
        {
            JsonObject jObjectResponse = (JsonObject)JsonObject.Parse(response);

            

            User user = JsonSerializer.Deserialize<User>(jObjectResponse["results"][0]);

            return user;
        }
    }
}

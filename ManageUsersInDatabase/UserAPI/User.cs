using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUsersInDatabase.UserAPI
{
    public class User
    {
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public DateOfBirth dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public ID id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }
    }
}

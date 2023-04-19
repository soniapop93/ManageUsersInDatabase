using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageUsersInDatabase.UserAPI
{
    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int postcode { get; set; }
        public Coordinates coordinates { get; set; }
        public Timezone timezone { get; set; }
    }
}

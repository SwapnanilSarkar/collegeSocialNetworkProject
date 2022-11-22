using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegeSocialNetworkProject.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string phoneNo { get; set; }
        public int isActive { get; set; }
        public int isApproved { get; set; }
        public string userType { get; set; }

    }
}

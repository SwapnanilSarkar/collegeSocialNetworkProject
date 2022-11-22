using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegeSocialNetworkProject.Models
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string content { get; set; }

        public string Email { get; set; }
        public string image { get; set; }
        public int isActive { get; set; }
        public string createOn { get; set; }
    }
}

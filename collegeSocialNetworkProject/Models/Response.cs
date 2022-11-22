using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collegeSocialNetworkProject.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusMsg { get; set; }
        public Registration registration { get; set; }

        public List<Registration> listRegistration { get; set; }
        public List<Articles> listArticles { get; set; }
        public List<News> listNews { get; set; }
        public List<Events> listEvents { get; set; }
        public List<Staff> listStaff { get; set; }
        public List<Student> listStudents { get; set; }
        public List<Officer> listOfficer{ get; set; }
        public List<Image> listImage { get; set; }
    }
}

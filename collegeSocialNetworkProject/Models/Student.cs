using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace collegeSocialNetworkProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public string Department  { get; set; }
        public int Marks { get; set; }
        public int Backlog { get; set; }

    }
}

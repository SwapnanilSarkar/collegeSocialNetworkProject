using collegeSocialNetworkProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace collegeSocialNetworkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("StudentAddition")]

        public Response StudentAddition(Student students)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.StudentAddition(students, connection);
            return response;
        }

        [HttpGet]
        [Route("StudentList")]

        public Response StudentList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.StudentList(connection);
            return response;
        }
    }
}

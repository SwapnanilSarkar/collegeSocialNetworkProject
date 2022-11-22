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
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// //////////
        /// </summary>
       
        /// <returns></returns>

        [HttpGet]
        [Route("RegistrationList")]

        public Response RegistrationList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.RegistrationList(connection);
            return response;
        }






        //FOR REGISTRATION API
        [HttpPost]
        [Route("Registration")]

        public Response Registration(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.Registration(registration, connection);
            return response;
        }
        //FOR LOGIN API
        [HttpPost]
        [Route("Login")]
        public Response Login(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.Login(registration, connection);
            return response;
        }

        //STAFF LOGIN 
        [HttpPost]
        [Route("StaffLogin")]
        public Response StaffLogin(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.StaffLogin(staff, connection);
            return response;
        }

        [HttpPost]
        [Route("OfficerLogin")]
        public Response OfficerLogin(Officer officer)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.OfficerLogin(officer, connection);
            return response;
        }

        //FOR APPROVAL API
        [HttpPost]
        [Route("UserApprove")]
        public Response UserApprove(Registration registration)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.UserApprove(registration, connection);
            return response;
        }
        //FOR STAFF FETCHING
        [HttpGet]
        [Route("staffFetching")]

        public Response staffFetching()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.staffFetching( connection);
            return response;
        }
        //FOR REGISTRATION OF STAFF API
        [HttpPost]
        [Route("staffRegistration")]

        public Response staffRegistration(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.staffRegistration(staff, connection);
            return response;
        }
        //FOR DLETION STAFF API
        [HttpPost]
        [Route("deleteStaff")]

        public Response deleteStaff(Staff staff)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.deleteStaff(staff, connection);
            return response;
        }
    }
}

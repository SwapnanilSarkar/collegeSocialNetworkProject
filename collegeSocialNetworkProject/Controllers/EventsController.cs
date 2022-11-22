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
    public class EventsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EventsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //FOR ADD NEWS API
        [HttpPost]
        [Route("AddEvents")]

        public Response AddEvents(Events events)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.AddEvents(events, connection);
            return response;
        }

        [HttpGet]
        [Route("EventsList")]

        public Response EventsList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.EventsList(connection);
            return response;
        }
    }
}

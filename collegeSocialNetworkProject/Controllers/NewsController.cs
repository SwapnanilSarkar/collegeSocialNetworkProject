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
    public class NewsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public NewsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //FOR ADD NEWS API
        [HttpPost]
        [Route("News")]

        public Response News(News news)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.News(news, connection);
            return response;
        }

        [HttpGet]
        [Route("NewsList")]

        public Response NewsList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.NewsList(connection);
            return response;
        }
    }
}

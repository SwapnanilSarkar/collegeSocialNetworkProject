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
    public class ArticleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //FOR ADD ARTICLE API
        [HttpPost]
        [Route("AddArticles")]

        public Response AddArticles(Articles articles)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.AddArticles(articles, connection);
            return response;
        }
        //FOR FETCH ARTICLE API
        [HttpGet]
        [Route("ArticlesList")]

        public Response ArticlesList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.ArticlesList(connection);
            return response;
        }

        [HttpGet]
        [Route("OfficerArticlesList")]

        public Response OfficerArticlesList()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.OfficerArticlesList(connection);
            return response;
        }

        [HttpGet]
        [Route("ArticlesListstudent")]

        public Response ArticlesListstudent()
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.ArticlesListstudent(connection);
            return response;
        }


        [HttpPost]
        [Route("ArticleApprove")]
        public Response ArticleApprove(Articles articles)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.ArticleApprove(articles, connection);
            return response;
        }

        [HttpPost]
        [Route("deleteArticle")]
        public Response deleteArticle(Articles articles)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Con").ToString());
            Dal dal = new Dal();
            response = dal.deleteArticle(articles, connection);
            return response;

        }


    }
}

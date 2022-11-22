using collegeSocialNetworkProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace collegeSocialNetworkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public IHostingEnvironment hostingEnvironment;
        public ImageUploadController(IConfiguration configuration, IHostingEnvironment hostingEnv)
        {
            hostingEnvironment = hostingEnv;
            _configuration = configuration;
        }
        public static string connectionString = "Data Source=SWAPNANIL-SARKA\\TEW_SQLEXPRESS;Initial Catalog=collegeSocialNetwork;integrated security=true";

        [HttpPost]
        [Route("UploadImage")]
        public Response UploadImage()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            Response response = new Response();
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        FileInfo fi = new FileInfo(file.FileName);
                        var newfilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
                        var path = Path.Combine("", hostingEnvironment.ContentRootPath + "\\Images\\" + newfilename);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        Image img = new Image();
                        img.imagepath = path;
                        img.InsertedOn = DateTime.Now;
                        SqlCommand cmd = new SqlCommand("INSERT INTO Image(imagepath,InsertedOn) VALUES('" + img.imagepath + "','" + img.InsertedOn + "')", connection);
                        //Articles img = new Articles();
                        /* img.image= path;
                         //img.InsertedOn = DateTime.Now;
                         SqlCommand cmd = new SqlCommand("INSERT INTO Article(Image) VALUES('" + img.image + "')", connection);*/
                        connection.Open();
                        int i = cmd.ExecuteNonQuery();
                        connection.Close();

                    }
                    response.statusCode = 200;
                    response.statusMsg = "Image Uploaded";
                    return response;
                }
                else
                {
                    response.statusMsg = "Select Image";
                    return response;
                }
            }
            catch (Exception e)
            {
                response.statusMsg = e.Message;
                return response;

            }
        }

        [HttpGet]
        [Route("GetImage")]
        public Response GetImage()
        {
            Response response = new Response();
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Image ", connectionString);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Image> listimage = new List<Image>();
            if (dt.Rows.Count > 0)
            {
                //Articles articles = new Articles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Image img = new Image();
                    img.imagepath = Convert.ToString(dt.Rows[i]["imagepath"]);
                    img.InsertedOn = Convert.ToDateTime(dt.Rows[i]["InsertedOn"]);
                    listimage.Add(img);
                }
                if (listimage.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "Image List Found";
                    response.listImage = listimage;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "Image List Not Found";
                    response.listImage = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "Image List Not Found";
                response.listImage = null;
            }
            return response;
        }
    }
}

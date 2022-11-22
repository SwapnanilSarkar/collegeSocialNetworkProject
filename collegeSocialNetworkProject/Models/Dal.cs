using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace collegeSocialNetworkProject.Models
{
    public class Dal
    {
        //FOR FETCHING REGISTRATION LIST
        public Response RegistrationList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Registration WHERE isActive=1", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Registration> listregs = new List<Registration>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Registration regs = new Registration();
                    regs.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    regs.Name = Convert.ToString(dt.Rows[i]["name"]);
                    regs.Email = Convert.ToString(dt.Rows[i]["email"]);
                    regs.password = Convert.ToString(dt.Rows[i]["PWd"]);
                    regs.phoneNo = Convert.ToString(dt.Rows[i]["phoneno"]);
                    regs.isActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    regs.isApproved = Convert.ToInt32(dt.Rows[i]["isApproved"]);
                    listregs.Add(regs);
                }
                if (listregs.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "registration list found";
                    response.listRegistration = listregs;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "registration list not found";
                    response.listRegistration = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "registration list not found";
                response.listRegistration = null;
            }
            return response;
        }

        public Response Registration(Registration registration,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(name,email,PWd,phoneno,isActive,isApproved) VALUES('" + registration.Name + "','" + registration.Email + "','" + registration.password + "','" + registration.phoneNo + "',1,0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                //if rows inserted then i>0
                response.statusCode = 200;
                response.statusMsg = "Resgistration successful";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "Resgistration failed";
            }

            return response;

        }

        public Response Login(Registration registration, SqlConnection connection)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Registration WHERE email='" + registration.Email + "' AND PWd='" + registration.password + "'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "login succefully done";
                Registration reg = new Registration();
                reg.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                reg.Name = Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["email"]);
                reg.isApproved = Convert.ToInt32(dt.Rows[0]["isApproved"]);
                response.registration = reg;
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "login failed";
                response.registration = null;

            }
            return response;
        }


        public Response StaffLogin(Staff staff, SqlConnection connection)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Staff WHERE email='" + staff.Email + "' AND PWd='" + staff.password + "'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "login succefully done";
                Staff reg = new Staff();
                List<Staff> listregs = new List<Staff>();
                reg.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                reg.Name = Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["email"]);
                //reg.isApproved = Convert.ToInt32(dt.Rows[0]["isApproved"]);
                listregs.Add(reg);
                response.listStaff=listregs;
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "login failed";
                response.registration = null;

            }
            return response;
        }

        public Response OfficerLogin(Officer officer, SqlConnection connection)

        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Officer WHERE email='" + officer.Email + "' AND PWd='" + officer.password + "'", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Response response = new Response();
            if (dt.Rows.Count > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "login succefully done";
                Officer reg = new Officer();
                List<Officer> listregs = new List<Officer>();
                reg.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                reg.Name = Convert.ToString(dt.Rows[0]["Name"]);
                reg.Email = Convert.ToString(dt.Rows[0]["email"]);
                //reg.isApproved = Convert.ToInt32(dt.Rows[0]["isApproved"]);
                listregs.Add(reg);
                response.listOfficer = listregs;
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "login failed";
                response.registration = null;

            }
            return response;
        }


        public Response UserApprove(Registration registration, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Registration SET isApproved=1 WHERE ID='" + registration.ID+"' AND isActive=1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "approved";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "approval denied";

            }
            connection.Close();
            return response;
        }

        public Response News(News news,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO News(title,content,email,isActive,createDate)VALUES('" + news.Title + "','" + news.content + "','" + news.Email + "','1',GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "news created";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "news not created";
            }
            return response;

        }

        public Response NewsList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM News WHERE isActive=1", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<News> listNews = new List<News>();
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    News news = new News();
                    news.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    news.Title = Convert.ToString(dt.Rows[i]["title"]);
                    news.content = Convert.ToString(dt.Rows[i]["content"]);
                    news.Email = Convert.ToString(dt.Rows[i]["email"]);
                    news.isActive= Convert.ToInt32(dt.Rows[i]["isActive"]);
                    news.createOn = Convert.ToString(dt.Rows[i]["createDate"]);
                    listNews.Add(news);
                }
                if (listNews.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "news found";
                    response.listNews = listNews;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "news not found";
                    response.listNews = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "news not found";
                response.listNews = null;
            }
            return response;
        }

        public Response AddArticles(Articles articles, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Article(title,content,email,Image,isActive,isApproved)VALUES('" + articles.Title + "','" + articles.content + "','" + articles.Email + "','"+articles.image+"',1,0)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "articles created";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "articles not created";
            }
            return response;

        }

        public Response ArticlesList( SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            /*// SqlDataAdapter sda = null;
            SqlDataAdapter sda=null;
            if (articles.type == "User")
            {
                sda=new SqlDataAdapter("SELECT * FROM Article WHERE email='" + articles.Email + "' AND isActive=1", connection);
            }
            if (articles.type == "Page")
            {
                sda=new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            }*/
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Articles> listArticles = new List<Articles>();
            if (dt.Rows.Count > 0)
            {
                //Articles articles = new Articles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Articles article = new Articles();
                    article.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    article.Title = Convert.ToString(dt.Rows[i]["title"]);
                    article.content = Convert.ToString(dt.Rows[i]["content"]);
                    article.Email = Convert.ToString(dt.Rows[i]["email"]);
                    article.image = Convert.ToString(dt.Rows[i]["Image"]);
                    article.isActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    article.isApproved = Convert.ToInt32(dt.Rows[i]["isApproved"]);
                    listArticles.Add(article);
                }
                if (listArticles.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "articles found";
                    response.listArticles = listArticles;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "articles not found";
                    response.listArticles = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "articles not found";
                response.listArticles = null;
            }
            return response;
        }

        //Addition of Officer Article

        public Response OfficerArticlesList(SqlConnection connection)

        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Article WHERE email LIKE 'officer%'", connection);
            /*// SqlDataAdapter sda = null;
            SqlDataAdapter sda=null;
            if (articles.type == "User")
            {
                sda=new SqlDataAdapter("SELECT * FROM Article WHERE email='" + articles.Email + "' AND isActive=1", connection);
            }
            if (articles.type == "Page")
            {
                sda=new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            }*/
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Articles> listArticles = new List<Articles>();
            if (dt.Rows.Count > 0)
            {
                //Articles articles = new Articles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Articles article = new Articles();
                    article.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    article.Title = Convert.ToString(dt.Rows[i]["title"]);
                    article.content = Convert.ToString(dt.Rows[i]["content"]);
                    article.Email = Convert.ToString(dt.Rows[i]["email"]);
                    article.image = Convert.ToString(dt.Rows[i]["Image"]);
                    article.isActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    article.isApproved = Convert.ToInt32(dt.Rows[i]["isApproved"]);
                    listArticles.Add(article);
                }
                if (listArticles.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "articles found";
                    response.listArticles = listArticles;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "articles not found";
                    response.listArticles = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "articles not found";
                response.listArticles = null;
            }
            return response;
        }


        //For Student
        public Response ArticlesListstudent(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1 AND isApproved=1", connection);
            /*// SqlDataAdapter sda = null;
            SqlDataAdapter sda=null;
            if (articles.type == "User")
            {
                sda=new SqlDataAdapter("SELECT * FROM Article WHERE email='" + articles.Email + "' AND isActive=1", connection);
            }
            if (articles.type == "Page")
            {
                sda=new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            }*/
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Articles> listArticles = new List<Articles>();
            if (dt.Rows.Count > 0)
            {
               
                //Articles articles = new Articles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Articles article = new Articles();
                    article.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    article.Title = Convert.ToString(dt.Rows[i]["title"]);
                    article.content = Convert.ToString(dt.Rows[i]["content"]);
                    article.Email = Convert.ToString(dt.Rows[i]["email"]);
                    article.image = Convert.ToString(dt.Rows[i]["Image"]);
                    article.isActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    article.isApproved = Convert.ToInt32(dt.Rows[i]["isApproved"]);
                   
                        listArticles.Add(article);
                        
                  
                }
                if (listArticles.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "articles found";
                    response.listArticles = listArticles;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "articles not found";
                    response.listArticles = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "articles not found";
                response.listArticles = null;
            }
            return response;
        }


        public Response ArticleApprove(Articles articles, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE Article SET isApproved=1 WHERE ID='" + articles.ID + "' AND isActive=1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "article approved";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "article approval denied";

            }
            connection.Close();
            return response;
        }
        //Staff Fetching
        public Response staffFetching(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Staff WHERE isActive=1", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Staff> listregs = new List<Staff>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   Staff regs = new Staff();
                    regs.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    regs.Name = Convert.ToString(dt.Rows[i]["name"]);
                    regs.Email = Convert.ToString(dt.Rows[i]["email"]);
                    regs.password = Convert.ToString(dt.Rows[i]["PWd"]);
                    regs.isActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    
                    listregs.Add(regs);
                }
                if (listregs.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "Staff list found";
                    response.listStaff = listregs;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "Staff list not found";
                    response.listStaff = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "registration list not found";
                response.listStaff = null;
            }
            return response;
        }
    
        //Staff Registration
        public Response staffRegistration(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Staff(name,email,PWd,isActive) VALUES('" + staff.Name + "','" + staff.Email + "','" + staff.password + "',1)", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                //if rows inserted then i>0
                response.statusCode = 200;
                response.statusMsg = "staff resgistration successful";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "staff resgistration failed";
            }

            return response;

        }

        public Response deleteStaff(Staff staff, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE ID ='" + staff.ID + "'AND isActive=1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                //if rows inserted then i>0
                response.statusCode = 200;
                response.statusMsg = "staff deletion successful";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "staff deletion failed";
            }

            return response;

        }

        //Delete Article
        public Response deleteArticle(Articles articles, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM Article WHERE  ID ='" + articles.ID + "'AND isActive=1", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                //if rows inserted then i>0
                response.statusCode = 200;
                response.statusMsg = "Article deletion successful";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "Article deletion failed";
            }

            return response;

        }

        public Response AddEvents(Events events, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Events(title,content,email,isActive,createDate)VALUES('" + events.Title + "','" + events.content + "','" + events.Email + "',1,GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "events created";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "events not created";
            }
            return response;

        }

        public Response EventsList(SqlConnection connection)
        {
            Response response = new Response();
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Events WHERE isActive=1", connection);
     
            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Events> listEvents = new List<Events>();
            if (dt.Rows.Count > 0)
            {
                //Articles articles = new Articles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Events events = new Events();
                    events.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    events.Title = Convert.ToString(dt.Rows[i]["title"]);
                    events.content = Convert.ToString(dt.Rows[i]["content"]);
                    events.Email = Convert.ToString(dt.Rows[i]["email"]);
                    //articles.image = Convert.ToString(dt.Rows[i]["Image"]);
                    events.isActive = Convert.ToInt32(dt.Rows[i]["isActive"]);
                    events.createOn= Convert.ToString(dt.Rows[i]["createDate"]);
                    listEvents.Add(events);
                }
                if (listEvents.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "events found";
                    response.listEvents = listEvents;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "events not found";
                    response.listEvents = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "events not found";
                response.listArticles = null;
            }
            return response;
        }


        public Response StudentAddition(Student students, SqlConnection connection)

        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO Student(name,rollNumber,department,marks,backlog)VALUES('" + students.Name + "','" + students.RollNumber + "','" + students.Department + "','"+ students.Marks+"','"+ students.Backlog + "')", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.statusMsg = "Student Added";
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "Student not added";
            }
            return response;

        }


        public Response StudentList(SqlConnection connection)

        {
            Response response = new Response();
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Article WHERE isActive=1", connection);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Student ", connection);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            List<Student> listStudents = new List<Student>();
            if (dt.Rows.Count > 0)
            {
                //Articles articles = new Articles();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Student students = new Student();
                    students.Id = Convert.ToInt32(dt.Rows[i]["iD"]);
                    students.Name = Convert.ToString(dt.Rows[i]["name"]);
                    students.RollNumber = Convert.ToInt32(dt.Rows[i]["rollNumber"]);
                    students.Department = Convert.ToString(dt.Rows[i]["department"]);
                    //articles.image = Convert.ToString(dt.Rows[i]["Image"]);
                    students.Marks = Convert.ToInt32(dt.Rows[i]["marks"]);
                    students.Backlog = Convert.ToInt32(dt.Rows[i]["backlog"]);
                    listStudents.Add(students);
                }
                if (listStudents.Count > 0)
                {
                    response.statusCode = 200;
                    response.statusMsg = "Student found";
                    response.listStudents = listStudents;
                }
                else
                {
                    response.statusCode = 100;
                    response.statusMsg = "Students not found";
                    response.listStudents = null;
                }
            }
            else
            {
                response.statusCode = 100;
                response.statusMsg = "Student not found";
                response.listStudents = null;
            }
            return response;
        }



    }
}

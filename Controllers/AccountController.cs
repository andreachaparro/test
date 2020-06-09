using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationLogin.Models;
using System.Data.SqlClient;


namespace WebApplicationLogin.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account1
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source= LAPTOP-9B3QJ4SS; database=DemoLogin; integrated security=SSPI;";
        }
        [HttpPost]
        public ActionResult verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username = '" + acc.Name + "' and password = '" + acc.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult addCount(Account acc)
        {
            //Account acc = new Account();
        
            connectionString();
            con.Open();
            com.Connection = con;
            acc.Name = Request.Form["username"].ToString();
            acc.edad = Request.Form["edad"].ToString();
            acc.telephone = Request.Form["telephone"].ToString();
            acc.email = Request.Form["email"].ToString();
            acc.Password = Request.Form["apellido"].ToString();
            com.CommandText = "insert into tbl_login values('" + acc.Name + "';'" + acc.edad + "';'" + acc.telephone + "';'" + acc.email + "';'" + acc.Password + "')";
            dr = com.ExecuteReader();
                con.Close();
                return View("Create");
   
        }
    }
}
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace SessionManagement.Controllers
{
  public class AuthController : Controller
  {
    // function to create a connection with mysql
    private MySqlConnection CreateConnection()
    {
        string connection = "server=localhost;database=businessclientsystem;user=dbuser;password=123qweasdzxc;port=3306"; // declaring a connection string
        MySqlConnection con = new MySqlConnection(connection); // creating the connection
        con.Open(); // openning the connection
        return con; // return the created connection
    }


    // function to execute when login button is clicked
    public IActionResult Login()
    {
      ViewData["error"] = false;
      ViewData["loginSuccessful"] = false;
      ViewData["userNotFound"] = false;
      return View();
    }

    // function to execute when logout button is clicked
    public IActionResult Logout()
    {
      HttpContext.Session.Clear(); // clearout the session
      return Redirect("/auth/login");
    }

    [HttpPost]
    // function to execute when user submits the login form
    public IActionResult Login(string email, string password)
    {
      try
      {
        var con = this.CreateConnection(); // call the connection function to get the connection
        string cmdText = $"select * from users where email = '{email}' and password = '{password}'"; // creating the query
        MySqlCommand cmd = new MySqlCommand(cmdText, con); // creating the mysql command
        var result = cmd.ExecuteReader(); // executing the query
        if(result.HasRows) // check whether query result has any rows or not
        {

          HttpContext.Session.SetString("user", email); // setting the the session in HttpContext

          ViewData["error"] = false;
          ViewData["loginSuccessful"] = true;
          ViewData["userNotFound"] = false;
          return View();

        }
        else
        {
          ViewData["error"] = false;
          ViewData["loginSuccessful"] = false;
          ViewData["userNotFound"] = true;
          return View();
        }

      }
      catch (Exception)
            {
        ViewData["error"] = true;
        ViewData["loginSuccessful"] = false;
        ViewData["userNotFound"] = false;
        return View();
      }
    }

    // function to execute when user clicks on the register
    public IActionResult Register()
    {
      ViewData["registrationSuccessful"] = false;
      ViewData["error"] = false;
      return View();
    }

    [HttpPost]
    // function to execute when user submit registration form
    public IActionResult Register(string firstName, string lastName, string email, string password)
    {
      try
      {
        var con = this.CreateConnection();
        string cmdText = $"insert into users(firstName, lastName, email, password) values('{firstName}', '{lastName}', '{email}', '{password}')";
        MySqlCommand cmd = new MySqlCommand(cmdText, con);
        cmd.ExecuteNonQuery();
        ViewData["registrationSuccessful"] = true;
        ViewData["error"] = false;
        return View();
      } catch (MySqlException)
            {
        ViewData["error"] = true;
        ViewData["registrationSuccessful"] = false;
        return View();
      }

    }

  }
}

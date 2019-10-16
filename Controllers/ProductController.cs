using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using SessionManagement.Models;

namespace SessionManagement.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
          var con = this.CreateConnection();
          string cText = $"select * from products";
          MySqlCommand cm = new MySqlCommand(cText, con);
          var result = cm.ExecuteReader();
          List<Product> products = new List<Product>();
          while(result.Read())
          {
            Product p = new Product();
            p.id = Convert.ToInt32(result["id"]);
            p.name = result["name"].ToString();
            p.price = Convert.ToDouble(result["price"]);
            p.pictureUrl = result["pictureUrl"].ToString();
            products.Add(p);
          }
          ViewBag.Products = products;
          return View();
        }

        public IActionResult View(int id)
        {
          var con = this.CreateConnection();
          string cText = $"select * from products where id = {id}";
          MySqlCommand cm = new MySqlCommand(cText, con);
          var result = cm.ExecuteReader();
          while(result.Read())
          {
            Product p = new Product();
            p.id = Convert.ToInt32(result["id"]);
            p.name = result["name"].ToString();
            p.price = Convert.ToDouble(result["price"]);
            p.pictureUrl = result["pictureUrl"].ToString();
            ViewBag.Product = p;
          }
          return View();
        }

        public IActionResult Add()
        {
          if(InvalidSession()) return ReturnToLogin();
          return View();
        }

        [HttpPost]
        public IActionResult Add(string name, double price, IFormFile picture)
        {
          string pictureUrl = null;
          if(picture.Length > 0)
          {
            var fileName = Path.GetFileName(picture.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/images", fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            picture.CopyTo(stream);
            pictureUrl = "/images/" + fileName;

          }
          var con = this.CreateConnection();
          string cmdText = $"insert into products(name, price, pictureUrl) values('{name}', {price}, '{pictureUrl}'); select last_insert_id();";
          MySqlCommand cmd = new MySqlCommand(cmdText, con);
          cmd.ExecuteNonQuery();
          return Redirect($"/product/view/?id={cmd.LastInsertedId}");
        }


        private MySqlConnection CreateConnection()
        {
            string connection = "server=localhost;database=SessionManagement;user=root;password=root;port=3306"; // declaring a connection string
            MySqlConnection con = new MySqlConnection(connection); // creating the connection
            con.Open(); // openning the connection
            return con; // return the created connection
        }

        private IActionResult ReturnToLogin()
        {
          return Redirect("/auth/login");
        }

        private bool InvalidSession()
        {
          return HttpContext.Session.GetString("user") == null;
        }
    }
}
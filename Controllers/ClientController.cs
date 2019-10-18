using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessClientSystem.Models;
using Microsoft.AspNetCore.Http;

namespace BusinessClientSystem.Controllers
{
    public class ClientController : Controller
    {
         public IActionResult New()
         {
            return View();
         }

         public IActionResult New1()
         {
            return View();
         }

          public IActionResult Sample()
         {
            return View();
         }

         [HttpPost]
         public RedirectResult New1(int id, string salutation, string firstname, string lastname, string contacttype,
         string gender, string dateofbirth, string address1, string address2, int phone1, int phone2, string email, string product)
         {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients();
            newClient.id = id;
            newClient.salutation = salutation;
            newClient.firstname = firstname;
            newClient.lastname = lastname;
            newClient.gender =  gender;
            newClient.contacttype = contacttype;
            newClient.dateofbirth = dateofbirth;
            newClient.address1 = address1;
            newClient.address2 = address2;
            newClient.phone1 = phone1;
            newClient.phone2 = phone2;
            newClient.gender = gender;
            newClient.email = email;
            newClient.product = product;
            cs.addClientToDB(newClient);
            return Redirect("/Client");
         }

          public IActionResult Profile(int id)
         {
            BusinessClient cs = new BusinessClient();
            ViewData["clients"] = cs.getClients(id);
            return View();
         }

           public IActionResult Profile1(int id)
         {
            BusinessClient cs = new BusinessClient();
            ViewData["clients"] = cs.getClients(id);
            return View();
         }

         [HttpPost]
         public RedirectResult New( string salutation, string firstname, string lastname, 
         string gender, string dateofbirth, string address1, string address2, int phone1, int phone2, string email)
         {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients();
           // newClient.id = id;
            newClient.salutation = salutation;
            newClient.firstname = firstname;
            newClient.lastname = lastname;
            newClient.gender =  gender;
            newClient.dateofbirth = dateofbirth;
            newClient.address1 = address1;
            newClient.address2 = address2;
            newClient.phone1 = phone1;
            newClient.phone2 = phone2;
            newClient.gender = gender;
            newClient.email = email;
            cs.addClientToDB(newClient);
            return Redirect("/Client");
         }

        
        public IActionResult Update(int id)
            {
            BusinessClient cs = new BusinessClient();
            ViewData["clients"] = cs.getClients(id);
            return View();
            }

       
        [HttpPost]
         public RedirectResult Update(int id, string salutation, string firstname, string lastname, string gender, string contacttype,
         string dateofBirth, string address1, string address2, int phone1, int phone2, string email, string product)
         {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients();
            newClient.id = id;
            newClient.salutation = salutation;
            newClient.firstname = firstname;
            newClient.lastname = lastname;
            newClient.gender = gender;
            newClient.contacttype = contacttype;
            newClient.dateofbirth = dateofBirth;
            newClient.address1 = address1;
            newClient.address2 = address2;
            newClient.phone1 = phone1;
            newClient.phone2 = phone2;
            newClient.email = email;
            newClient.product = product;
            cs.updateClientToDB(newClient);
            return Redirect("/Client");
        }

         public IActionResult Update1(int id)
            {
            BusinessClient cs = new BusinessClient();
            ViewData["clients"] = cs.getClients(id);
            return View();
            }
         
         [HttpPost]
         public RedirectResult Update1(int id, string salutation, string firstname, string lastname, string gender, string contacttype,
         string dateofBirth, string address1, string address2, int phone1, int phone2, string email, string product)
         {
            BusinessClient cs = new BusinessClient();
            Clients newClient = new Clients();
            newClient.id = id;
            newClient.salutation = salutation;
            newClient.firstname = firstname;
            newClient.lastname = lastname;
            newClient.gender = gender;
            newClient.contacttype = contacttype;
            newClient.dateofbirth = dateofBirth;
            newClient.address1 = address1;
            newClient.address2 = address2;
            newClient.phone1 = phone1;
            newClient.phone2 = phone2;
            newClient.email = email;
            newClient.product = product;
            cs.updateClientToDB(newClient);
            return Redirect("/Client");
        }

        public IActionResult Search()
        {
            return View();
        }

        public RedirectResult Delete(int id)
          {
               BusinessClient cs = new BusinessClient();
               cs.deleteClient(id);
                return Redirect("/client");
            }


         public IActionResult Index()
         {
            var user = HttpContext.Session.GetString("user");
            if(user == null)
            {
              return Redirect("/auth/login");
            }
            else
            {
            BusinessClient cs = new BusinessClient();
            ViewData["clients"] = cs.getClientsFromDb();
            return View();
            }
            
             
             
        }
    }
}

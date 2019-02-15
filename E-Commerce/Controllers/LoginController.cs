using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        CommerceContext db = new CommerceContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newCustomer);
        }
       

    }
}
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Login

        CommerceContext db = new CommerceContext();
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(string a)
        {
            return View();
        }
        [HttpPost]
        public JsonResult Customer(Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                RedirectToAction("Index");
                return Json(true);
            }
            return Json(false);
        }
    } 
}

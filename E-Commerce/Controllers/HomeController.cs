using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        CommerceContext db = new CommerceContext();
        // GET: Home
        public ActionResult Index(int? id)
        {
            var list = db.Products.ToList();
            if (id.HasValue)
                list = db.Products.Where(x => x.CategoryId == id).ToList();
            ViewBag.Categories = db.Categories.Take(6).ToList();
            return View(list);
        }

        public ActionResult _Menu()
        {
            ViewBag.Categories = db.Categories.Where(x => x.ParentId == null).ToList();
            return View();
        }

        public ActionResult _Footer()
        {
            return View();
        }

        public ActionResult _Slider()
        {
            ViewBag.Products = db.Products.OrderByDescending(x => x.Id).Take(15).ToList();
            return View();
        }

        public ActionResult _MinCart()
        {
            //if (Session["Id"] == null)
               // Response.Redirect("Home");

            var customerId = Session["Id"];
            Customer c = db.Customers.Find(customerId);
           
            return View(c.Cart);
        }
    }
}
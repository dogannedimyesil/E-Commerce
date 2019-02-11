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
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.Take(6).ToList();
            ViewBag.Products = db.Products.OrderByDescending(x => x.Id).Take(15).ToList();
            return View();
        }
    }
}
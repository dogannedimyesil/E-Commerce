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
            return View(db.Categories.Take(5).ToList());
        }

        public ActionResult _Slider()
        {
            ViewBag.Products = db.Products.OrderByDescending(x => x.Id).Take(15).ToList();
            return View();
        }

        public ActionResult _MinCart()
        {
            Customer c = new Customer();
            if (c.Cart == null)
                c.Cart = new Cart();
            if (c.Cart.CartDetail == null)
                c.Cart.CartDetail = new List<CartDetail>();
            if (Session["Id"] == null)
            {
                ViewBag.count = 0;
            }
            else
            {
                var customerId = Session["Id"];
                c = db.Customers.Find(customerId);
                ViewBag.count =  c.Cart.CartDetail.Count;
            }
            return View(c.Cart);

        }
    }
}
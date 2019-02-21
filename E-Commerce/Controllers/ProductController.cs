using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
        CommerceContext db = new CommerceContext();
        public ActionResult Index(int ? id, HttpPostedFileBase[] image)
        {
            ViewBag.HighPrice = db.Products.OrderBy(x => x.Price);
            ViewBag.Price = db.Products.OrderByDescending(x => x.Price);
            ViewBag.Categories = db.Categories.ToList();
            if (id.HasValue)
                return View(db.Products.Where(x => x.CategoryId == id).ToList());
            else
                return View(db.Products.ToList());
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var products = from p in db.Products select p;
            if (!String.IsNullOrEmpty(search))
                products = products.Where(x => x.Name.Contains(search));

            ViewBag.HighPrice = db.Products.OrderBy(x => x.Price);
            ViewBag.Price = db.Products.OrderByDescending(x => x.Price);
            ViewBag.Categories = db.Categories.ToList();
            return View("Index", "",  products.ToList());
        }

        public ActionResult ProductDetail(int id)
        {
            return View(db.Products.Find(id));
        }
    }
}
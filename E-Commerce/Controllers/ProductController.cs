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
        public ActionResult Index(int? id,string sorting, HttpPostedFileBase[] image)
        {
            var list = db.Products.ToList();
            if (id.HasValue)
                list = db.Products.Where(x => x.CategoryId == id).ToList();
            switch (sorting)
            {
                case "1":
                    list = list.OrderByDescending(x => x.Price).ToList();
                    break;
                case "2":
                    list = list.OrderBy(x => x.Price).ToList();
                    break;
                default:
                    break;
            }
            ViewBag.Categories = db.Categories.ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var products = from p in db.Products select p;
            if (!String.IsNullOrEmpty(search))
                products = products.Where(x => x.Name.Contains(search));

           
            ViewBag.Categories = db.Categories.ToList();
            return View("Index", "",  products.ToList());
        }

        public ActionResult ProductDetail(int id)
        {
            return View(db.Products.Find(id));
        }
        
    }
}
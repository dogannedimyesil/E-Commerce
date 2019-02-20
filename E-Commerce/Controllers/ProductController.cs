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
            ViewBag.Categories = db.Categories.ToList();
            if (id.HasValue)
                return View(db.Products.Where(x => x.CategoryId == id).ToList());
            else
                return View(db.Products.ToList());
        }

        public ActionResult ProductDetail(int id)
        {
            return View(db.Products.Find(id));
        }
    }
}
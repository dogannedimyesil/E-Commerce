using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Panel.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Panel/Products
        CommerceContext db = new CommerceContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PossibleParents = db.Products.ToList();
            return View();
        }
    }
}
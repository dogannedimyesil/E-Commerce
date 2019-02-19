using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        CommerceContext db = new CommerceContext();
        public ActionResult Index()
        {
            return View(db.Carts.ToList());
        }

        [HttpPost]
        public JsonResult AddToCart(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
    }
}
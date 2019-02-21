using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public JsonResult AddToCart(CartDetail cart)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Id == 21);
            
            if (ModelState.IsValid)
            {
                customer.Cart.CartDetail.Add(cart);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
    }
}
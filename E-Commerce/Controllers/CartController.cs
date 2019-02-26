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
            if (Session["Id"] == null)
                return View();
            else
            {
                var id = Session["Id"];
                Customer c = db.Customers.Find(id);
                return View(c.Cart);
            }
        }

        public ActionResult Delete(int id)
        {
            var customerid = Session["Id"];
            Customer c = db.Customers.Find(customerid);
            CartDetail deleted = db.CartDetails.Find(id);
            c.Cart.CartDetail.Remove(deleted);
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult AddToCart(int id,string count,Size size, string color)
        {

            if (Session["Id"] == null)
            {
                Response.Redirect("Home");
            }
            var customerid = Session["Id"];

            Customer c = db.Customers.Find(customerid);
            if (c.Cart == null)
                c.Cart = new Cart();
            
            if (c.Cart.CartDetail == null)
                c.Cart.CartDetail = new List<CartDetail>();
          
            CartDetail cd = new CartDetail();
            cd.Product = db.Products.Find(id);
            cd.Quantity = Convert.ToInt32(count);
            cd.Product.Size = size;
            cd.Product.Color = color;
           
            if (ModelState.IsValid)
            {
                c.Cart.CartDetail.Add(cd);
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}
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
            var id = Session["Id"];
            Customer c = db.Customers.Find(id);
            return View(c.Cart);
           
        }

        [HttpPost]
        public JsonResult AddToCart(int id )
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
            //cd.Quantity = 
           
            if (ModelState.IsValid)
            {
                c.Cart.CartDetail.Add(cd);
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }
    }
}
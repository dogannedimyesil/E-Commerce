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
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product newProduct, HttpPostedFileBase[] productImage, int CategoryIds, int sizes )
        {
            newProduct.Category = new Category();
            newProduct.CategoryId = CategoryIds;
            newProduct.Size = new Size();
            newProduct.Size = sizes;
            newProduct.ProductImages = new List<ProductImage>();
            foreach (var item in productImage)
            {
                ProductImage p = new ProductImage();
                p.ImageURL = item.FileName;
                newProduct.ProductImages.Add(p);
            }
            if (ModelState.IsValid)
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        
    }
}
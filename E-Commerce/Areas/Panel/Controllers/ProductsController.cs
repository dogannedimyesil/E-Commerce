using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Panel.Controllers
{
    public class ProductsController : Controller
    {
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
        public ActionResult Create(Product newProduct, HttpPostedFileBase[] productImage, int CategoryIds,  Size sizes)
        {
           
            newProduct.CategoryId = CategoryIds;
         
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
       
        [HttpGet]
        public ActionResult Edit(int id)
        {            
            ViewBag.Categories = db.Categories.ToList();
            return View(db.Products.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Product edited, HttpPostedFileBase[] productImage, int CategoryIds, Size Size)
        {
            edited.CategoryId = CategoryIds;
            edited.Size = Size;
            edited.ProductImages = new List<ProductImage>();
            foreach (var item in productImage)
            {
                ProductImage p = new ProductImage();
                p.ImageURL = item.FileName;
                edited.ProductImages.Add(p);
            }
            if (ModelState.IsValid)
            { 
                var old = db.Products.Find(edited.Id);
                old.Name = edited.Name;
                old.Price = edited.Price;
                old.Color = edited.Color;
                old.Description = edited.Description;
                old.ProductQuantity = edited.ProductQuantity;
                old.Size = edited.Size;
                old.CategoryId = edited.CategoryId;
                db.Entry(old).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(edited);
        }
       
    }
}
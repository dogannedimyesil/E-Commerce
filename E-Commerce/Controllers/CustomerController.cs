using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Login

        CommerceContext db = new CommerceContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Email, string Password)
        {
            bool? isTrue = false;
            Customer customer = new Customer();
            List<Customer> ListCustomers = db.Customers.ToList();
            foreach (var item in ListCustomers)
            {
                if (Email == item.Email)
                {
                    if (Password == item.Password)
                    {
                        isTrue = true;
                        Session["Email"] = item.Email;
                        Session["NameSurname"] = item.NameSurname;
                        Session["Id"] = item.Id;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ViewBag.Message("Geçerli bilgi giriniz.");
            return View(isTrue);
        }

        [HttpGet]
        public ActionResult Index(string a)
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult Customer(Customer customer, string Password, string Password2)
        {
            if (Password == Password2)
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    RedirectToAction("Customer");
                    return Json(true);
                }
            }

            return Json(false);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string Mail)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress("kucukaydin35@gmail.com");
            email.To.Add(Mail);
            email.Subject = "Reset your Le Nedimo password!!";
            email.Body = "http://localhost:61095/Customer/ResetPassword?Mail=" + Mail;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("kucukaydin35@gmail.com", "s41mb3yl1");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(email);
            return View(true);
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string newPassword, string newPassword2)
        {
            bool? Control = false;
            ViewBag.CheckinPassword = "Passwords must be same!";
            if (newPassword == newPassword2)
            {
                string Mail = Request.QueryString["Mail"];
                Customer Account = db.Customers.Where(x => x.Email == Mail).FirstOrDefault();
                Account.Password = newPassword;
                db.Entry(Account).State = EntityState.Modified;
                db.SaveChanges();
                Control = true;
                RedirectToAction("Index");
            }
            return View(Control);
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}

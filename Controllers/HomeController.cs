using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookHub.Models;

namespace BookHub.Controllers
{
    public class HomeController : Controller
    {
        private BookHubEntities db = new BookHubEntities();
        public ActionResult Index()
        {
            var book = db.BookDetails.Where(x => x.BookName.StartsWith("Star Wars"));
            return View(book);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult OurTeam()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchResult(string searching)
        {
            if (!String.IsNullOrEmpty(searching))
            {
                var list = db.BookDetails.Where(x => x.BookName.StartsWith(searching)).ToList();
                if (list != null)
                {
                    return View(list);
                }
                else
                {
                    var list2 = db.BookDetails.Where(x => x.AuthorName.StartsWith(searching)).ToList();
                    return View(list2);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
            
            
        }

        [HttpPost]
        public ActionResult ContactUs(ContactU c)
        {
            ContactU u = new ContactU();

            u.UserName = c.UserName;
            u.UserEmail = c.UserEmail;
            u.Subject = c.Subject;
            u.Message = c.Message;

            db.ContactUs.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}
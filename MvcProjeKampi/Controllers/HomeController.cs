using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult HomePage(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.Read = false;
            cm.ContactAdd(contact);

            var headingCount = c.Headings.Count();
            ViewBag.hc = headingCount;

            var entryCount = c.Contents.Count();
            ViewBag.ec = entryCount;

            var wrtierCount = c.Writers.Count();
            ViewBag.wc = wrtierCount;

            var categoryCount = c.Categories.Count();
            ViewBag.cc = categoryCount;
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult PartialGelistirme()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult PartialYaptıklarım()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult PartialGörseller()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult PartialProjeyeDair()
        {
            return PartialView();
        }
    }
}
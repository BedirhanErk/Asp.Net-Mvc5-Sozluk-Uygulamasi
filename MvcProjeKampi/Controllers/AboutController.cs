using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index(int page = 1)
        {
            var aboutValues = abm.GetList().ToPagedList(page, 10);
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAdd(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AddAboutPartial()
        {
            return PartialView();
        }
        public ActionResult ChangeStatus(int id)
        {
            var about = abm.GetById(id);
            if (about.Status == false)
            {
                about.Status = true;
            }
            else
            {
                about.Status = false;
            }
            abm.AboutDelete(about);
            return RedirectToAction("Index");
        }
    }
}
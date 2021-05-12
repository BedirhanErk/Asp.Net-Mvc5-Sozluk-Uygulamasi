using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var totalcategory = _context.Categories.Count().ToString();
            ViewBag.totalcategory = totalcategory;

            var totalyheading = _context.Headings.Count(x => x.CategoryId == 9).ToString();
            ViewBag.totalyheading = totalyheading;

            var writera = _context.Writers.Count(x => x.WriterName.ToLower().Contains("a")).ToString();
            ViewBag.writera = writera;

            var mostheading = _context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.mostheading = mostheading;

            var categorytrue = _context.Categories.Count(x => x.CategoryStatus == true);
            var categoryfalse = _context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.categorydiff = (categorytrue - categoryfalse);

            return View();
        }
    }
}
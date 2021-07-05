using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyehat",
                CategoryCount = 12
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 50
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 2
            });
            return ct;
        }
        public ActionResult PieChart()
        {
            return View();
        }
        public ActionResult WriterHeadingChart()
        {
            return Json(WriterHeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<WritersHeadingsCount> WriterHeadingList()
        {
            List<WritersHeadingsCount> whc = new List<WritersHeadingsCount>();
            using (var c = new Context())
            {
                whc = c.Writers.Select(x => new WritersHeadingsCount
                {
                    WriterName = x.WriterName  + " " +  x.WriterSurname,
                    HeadingCount = x.Headings.Count()
                }).ToList();
            }
            return whc;
        }
        public ActionResult LineChart()
        {
            return View();
        }
        public ActionResult CategoriesHeadingChart()
        {
            return Json(CategoriesHeadingList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoriesHeadingsCount> CategoriesHeadingList()
        {
            List<CategoriesHeadingsCount> chc = new List<CategoriesHeadingsCount>();
            using (var c= new Context())
            {
                chc = c.Categories.Select(x => new CategoriesHeadingsCount
                {
                    CategoryName = x.CategoryName,
                    HeadingCount = x.Headings.Count()
                }).ToList();
            }
            return chc;
        }
        public ActionResult ColumnChart()
        {
            return View();
        }
        public ActionResult HeadingsContentChart()
        {
            return Json(HeadingsContentList(), JsonRequestBehavior.AllowGet);
        }
        public List<HeadingsContentCount> HeadingsContentList()
        {
            List<HeadingsContentCount> hcc = new List<HeadingsContentCount>();
            using (var c = new Context())
            {
                hcc = c.Headings.Select(x => new HeadingsContentCount
                {
                    HeadingName = x.HeadingName,
                    ContentCount = x.Contents.Count()
                }).ToList();
            }
            return hcc;
        }
    }
}
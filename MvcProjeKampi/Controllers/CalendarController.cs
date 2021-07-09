using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CalendarController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            return View(new CalendarEvent());
        }
        public JsonResult GetCalenderEvents(DateTime start, DateTime end)
        {
            var viewModel = new CalendarEvent();
            var eventItems = new List<CalendarEvent>();

            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-14);

            foreach (var x in hm.GetList())
            {
                eventItems.Add(new CalendarEvent()
                {
                    title = x.HeadingName,
                    start = x.HeadingDate,
                    end = x.HeadingDate.AddDays(-14),
                    allDay = false,
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }
            return Json(eventItems, JsonRequestBehavior.AllowGet);
        }        
    }
}
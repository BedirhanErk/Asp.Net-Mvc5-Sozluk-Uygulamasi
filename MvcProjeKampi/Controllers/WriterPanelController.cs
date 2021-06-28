using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using EntityLayer.Dtos;
using BusinessLayer.Abstract;
using System.IO;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        Context c = new Context();
        [HttpGet]
        public ActionResult WriterProfile()
        {
            int id = 0;
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            WriterProfileEditDto writerProfileEditDto = new WriterProfileEditDto
            {
                WriterId = id,
                WriterMail = wm.GetById(id).WriterMail,
                WriterName = wm.GetById(id).WriterName,
                WriterSurname = wm.GetById(id).WriterSurname,
                WriterAbout = wm.GetById(id).WriterAbout,
                WriterImage = wm.GetById(id).WriterImage,
                WriterTitle = wm.GetById(id).WriterTitle,
                WriterStatus = wm.GetById(id).WriterStatus,
            };
            var image = wm.GetById(id).WriterImage;
            ViewBag.img = image;
            var name = wm.GetById(id).WriterName;
            ViewBag.nm = name;
            var surname = wm.GetById(id).WriterSurname;
            ViewBag.sn = surname;
            var title = wm.GetById(id).WriterTitle;
            ViewBag.tit = title;
            return View(writerProfileEditDto);
        }
        [HttpPost]
        public ActionResult WriterProfile(WriterProfileEditDto writerProfileEditDto)
        {
            IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
            ValidationResult results = writervalidator.Validate(writerProfileEditDto);
            if (results.IsValid )
            {
                if (writerProfileEditDto.WriterImage != null)
                {
                    if (Request.Files.Count > 0)
                    {
                        string filesname = Path.GetFileName(Request.Files[0].FileName);
                        string extension = Path.GetExtension(Request.Files[0].FileName);
                        string road = "~/Image/" + filesname + extension;
                        Request.Files[0].SaveAs(Server.MapPath(road));
                        writerProfileEditDto.WriterImage = "/Image/" + filesname + extension;
                    }
                }               
                authService.WriterEdit(writerProfileEditDto);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult WriterHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = hm.GetListByWriter(writerIdInfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writerMailInfo = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //NOTE: Session
            heading.WriterId = writerIdInfo;
            //
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("WriterHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var value = hm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("WriterHeading");
        }
        public ActionResult Delete(int id)
        {
            var value = hm.GetById(id);
            value.HeadingStatus = false;
            hm.HeadingDelete(value);
            return RedirectToAction("WriterHeading");
        }
        public ActionResult AllHeading(int page = 1)
        {
            var values = hm.GetList().ToPagedList(page, 6);
            return View(values);
        }
    }
}
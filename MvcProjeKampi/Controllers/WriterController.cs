using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = wm.GetList();
            return View(writerValues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(WriterProfileEditDto writerProfileEditDto)
        {
            IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
            ValidationResult results = writervalidator.Validate(writerProfileEditDto);
            if (results.IsValid)
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
                authService.WriterAdd(writerProfileEditDto);
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
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
            return View(writerProfileEditDto);
        }
        [HttpPost]
        public ActionResult EditWriter(WriterProfileEditDto writerProfileEditDto)
        {
            IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
            ValidationResult results = writervalidator.Validate(writerProfileEditDto);
            if (results.IsValid)
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
                return RedirectToAction("Index");
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
    }
}
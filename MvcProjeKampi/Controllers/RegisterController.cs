﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CaptchaMvc.HtmlHelpers;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()),new WriterManager(new EfWriterDal()));
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminDto adminDto)
        {
            if (!this.IsCaptchaValid(errorText:""))
            {
                ViewBag.ErrorMessage = "Doğrulama yanlış!";
                return View("Index",adminDto);
            }
            authService.Register(adminDto.AdminUserName,adminDto.AdminPassword,adminDto.RoleId,adminDto.AdminName);
            return RedirectToAction("Index","Login");
        }
        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterLoginDto writerLoginDto)
        {
            if (!this.IsCaptchaValid(errorText: ""))
            {
                ViewBag.ErrorMessage = "Doğrulama yanlış!";
                return View("WriterRegister", writerLoginDto);
            }
            authService.WriterRegister(writerLoginDto.WriterMail, writerLoginDto.WriterPassword);
            return RedirectToAction("WriterLogin","Login");
        }
    }
}
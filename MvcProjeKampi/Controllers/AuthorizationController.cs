using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcProjeKampi.Models;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        public ActionResult Index(int page = 1)
        {
            var values = adminManager.GetList().ToPagedList(page, 10);
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.RoleName,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();
            ViewBag.valueAdminRole = adminRoleValue;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(AdminDto adminDto)
        {
            authService.AdminAdd(adminDto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.RoleName,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();
            ViewBag.valueAdminRole = adminRoleValue;
            var value = adminManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var value = adminManager.GetById(id);
            if (value.AdminStatus == true)
            {
                value.AdminStatus = false;
            }
            else
            {
                value.AdminStatus = true;
            }
            adminManager.AdminDelete(value);
            return RedirectToAction("Index");
        }
    }
}
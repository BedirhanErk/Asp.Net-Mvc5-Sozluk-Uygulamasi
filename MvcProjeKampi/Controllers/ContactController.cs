using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetail(int id)
        {
            var contactValue = cm.GetById(id);
            contactValue.Read = true;
            cm.ContactUpdate(contactValue);
            return View(contactValue);
        }
        public PartialViewResult LeftMenuPartial()
        {
            //var contactMessageNumber = cm.GetList().Count().ToString();
            //ViewBag.cmc = contactMessageNumber;

            //var inboxNumber = mm.GetListInbox().Count.ToString();
            //ViewBag.inn = inboxNumber;

            //var sendboxNumber = mm.GetListSendbox().Count().ToString();
            //ViewBag.sn = sendboxNumber;

            //var draftnumber = mm.GetListDraft().Count().ToString();
            //ViewBag.dn = draftnumber;

            //var trashnumber = mm.GetListTrash().Count().ToString();
            //ViewBag.tn = trashnumber;

            var unRead = mm.GetUnReadMessageForInbox().Count().ToString();
            ViewBag.unr = unRead;

            var unReadContact = cm.GetUnReadMessageForContact().Count().ToString();
            ViewBag.unrc = unReadContact;
            return PartialView();
        }
        public ActionResult Delete(int id)
        {
            var contact = cm.GetById(id);
            cm.ContactFullyDelete(contact);
            return RedirectToAction("Index");
        }
    }
}
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetail(int id)
        {
            var messageValue = mm.GetById(id);
            messageValue.Read = true;
            mm.MessageUpdate(messageValue);
            return View(messageValue);
        }
        public PartialViewResult WriterLeftMenuPartial()
        {
            string p = (string)Session["WriterMail"];
            var unRead = mm.GetUnReadMessageForInbox(p).Count().ToString();
            ViewBag.unr = unRead;
            return PartialView();
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListSendbox(p);
            return View(messageList);
        }
        public ActionResult GetSendboxMessageDetail(int id)
        {
            var messageValue = mm.GetById(id);
            return View(messageValue);
        }
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "NewMessage")]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(message);
            if (results.IsValid)
            {     
                message.SenderMail = sender;
                message.SenderStatus = true;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
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
        public ActionResult GetListDraft()
        {
            string p = (string)Session["WriterMail"];
            var draftList = mm.GetListDraft(p);
            return View(draftList);
        }
        public ActionResult GetMessageDetail(int id)
        {
            var messageValue = mm.GetById(id);
            return View(messageValue);
        }
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "SaveDraft")]
        [ValidateInput(false)]
        public ActionResult SaveDraft(Message msg)
        {
            string sender = (string)Session["WriterMail"];
            msg.Draft = true;
            msg.SenderStatus = true;
            msg.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            msg.SenderMail = sender;
            mm.MessageAdd(msg);
            return RedirectToAction("GetListDraft");
        }
        public ActionResult TrashList()
        {
            string p = (string)Session["WriterMail"];
            var trash = mm.GetListTrash(p);
            return View(trash);
        }
        public ActionResult MakePassive(int id)
        {
            string p = (string)Session["WriterMail"];
            var message = mm.GetById(id);
            if (message.ReceiverMail == p)
            {
                message.ReceiverStatus = true;
            }
            else if (message.SenderMail == p)
            {
                message.SenderStatus = false;
            }
            mm.MessageDelete(message);
            return RedirectToAction("TrashList");
        }
        public ActionResult Delete(int id)
        {
            var message = mm.GetById(id);
            message.ReceiverDelete = true;
            mm.MessageFullyDelete(message);
            return RedirectToAction("TrashList");
        }
        public ActionResult TrashDetails(int id)
        {
            var messageValue = mm.GetById(id);
            return View(messageValue);
        }
    }
}
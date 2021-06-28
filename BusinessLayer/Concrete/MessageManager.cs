using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListDraft(string p)
        {
            return _messageDal.List(x => x.Draft == true && x.SenderMail == p && x.SenderStatus == false).OrderByDescending(y=>y.MessageDate).ToList();
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.ReceiverStatus == false && x.Draft == false).OrderBy(x => x.MessageDate).OrderByDescending(y=>y.MessageDate).ToList();
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.Draft == false && x.SenderStatus == true && x.ReceiverDelete == false).OrderByDescending(y=>y.MessageDate).ToList();
        }

        public List<Message> GetListTrash(string p)
        {
            return _messageDal.List(x => x.ReceiverStatus == true && x.ReceiverMail == p && x.ReceiverDelete == false).OrderByDescending(y=>y.MessageDate).ToList();
        }

        public List<Message> GetUnReadMessageForInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.ReceiverStatus == false && x.Read == false && x.Draft == false);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Update(message);
        }

        public void MessageFullyDelete(Message message)
        {
            _messageDal.Update(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}

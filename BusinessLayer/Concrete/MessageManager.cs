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

        public List<Message> GetListDraft()
        {
            return _messageDal.List(x => x.Draft == true && x.SenderMail == "admin@gmail.com" && x.Status == false);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com" && x.Status == false).OrderBy(x => x.MessageDate).ToList();
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.Draft == false && x.Status == false);
        }

        public List<Message> GetListTrash()
        {
            return _messageDal.List(x => x.Status == true);
        }

        public List<Message> GetUnReadMessageForInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com" && x.Status == false && x.Read == false);
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
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}

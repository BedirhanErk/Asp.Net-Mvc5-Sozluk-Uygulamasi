using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetListDraft();
        List<Message> GetListTrash();
        List<Message> GetUnReadMessageForInbox();
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageFullyDelete(Message message);
        void MessageUpdate(Message message);
    }
}

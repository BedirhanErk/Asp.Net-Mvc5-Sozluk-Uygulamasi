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
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetListDraft(string p);
        List<Message> GetListTrash(string p);
        List<Message> GetUnReadMessageForInbox(string p);
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageFullyDelete(Message message);
        void MessageUpdate(Message message);
    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mailini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");

            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Girilen ifade mail formatında olmalıdır");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu en az 3 karekterden oluşmalıdır");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu en fazla 100 karekterden oluşmalıdır");
        }
    }
}

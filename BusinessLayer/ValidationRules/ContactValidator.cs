using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen, en az 3 karekter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen, en fazla 50 karekter girişi yapınız");
            RuleFor(x => x.Message).MinimumLength(30).WithMessage("Lütfen, en az 30 karekter girişi yapınız");
        }
    }
}

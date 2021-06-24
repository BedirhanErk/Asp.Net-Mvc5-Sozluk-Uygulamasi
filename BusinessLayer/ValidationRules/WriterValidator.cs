using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adnını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında kısmını boş geçemezsiniz");      
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvanı kısmını boş geçemezsiniz");     
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karekter girişi yapınız");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karekterden fazla değer girişi yapmayınız");

            // Hakkımızda kısmı 'a' karekteri içermelidir.
            //RuleFor(x => x.WriterAbout).Must(y => y.Contains("a")).WithMessage("Yazar hakkında kısmı a karekteri içermelidir").When(z=> !string.IsNullOrEmpty(z.WriterAbout));
        }
    }
}

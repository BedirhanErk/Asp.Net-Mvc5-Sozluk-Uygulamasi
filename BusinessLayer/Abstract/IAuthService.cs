using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void Register(string adminMail, string password);
        bool Login(LoginDto loginDto);
        void WriterRegister(string mail, string password);
        bool WriterLogin(WriterLoginDto writerLoginDto);
        void WriterEdit(WriterProfileEditDto writerProfileEditDto);
        void WriterAdd(WriterProfileEditDto writerProfileEditDto);
        void AdminEdit(AdminDto adminDto);
        void AdminAdd(AdminDto adminDto);
    }
}

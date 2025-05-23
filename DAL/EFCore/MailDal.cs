using DAL.EFCore.Abstract;
using DAL.EFCore.Context;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore
{
    public class MailDal : IMailDal
    {
        private readonly DataContext _context;

        public MailDal(DataContext context)
        {
            _context = context;
        }

        public int Sendmail(string mail)
        {
            Mail m = new Mail();
            m.Subject = "Abonelik";
            m.IsHtml = true;
            m.From = "xinedd1@gmail.com";
            m.To.Add(mail);
            m.Message = "Aylık Abonelik";
            _context.Mails.Add(m);
            return _context.SaveChanges();
        }
     
    }
}

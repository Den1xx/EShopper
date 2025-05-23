using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore.Abstract
{
    public interface IMailDal
    {
        int Sendmail(string mail);
    }
}

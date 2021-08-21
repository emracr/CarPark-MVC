using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLoginLogDal : EfEntityRepositoryBase<LoginLog, CarparkContext>, ILoginLogDal
    {
        public List<LoginLogDetailsDto> GetLoginLogDetails()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from ll in context.LoginLogs
                             join c in context.Customers
                             on ll.CustomerId equals c.Id
                             select new LoginLogDetailsDto()
                             {
                                 Id = ll.Id,
                                 TC = c.TC,
                                 FirstName = c.Ad,
                                 LastName = c.Soyad,
                                 DateOfLogin = ll.DateOfLogin,
                                 DateOfLogout = ll.DateOfLogout
                             };

                return result.ToList();
            }
        }
    }
}

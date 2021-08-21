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
    public class EfDeletedCustomerDal : EfEntityRepositoryBase<DeletedCustomer, CarparkContext>, IDeletedCustomerDal
    {
        public List<DeletedCustomersDto> GetDeletedCustomers()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from dc in context.DeletedCustomers
                             join g in context.Genders
                             on dc.Gender equals g.Id
                             select new DeletedCustomersDto()
                             {
                                 Id = dc.Id,
                                 TC = dc.TC,
                                 FirstName = dc.FirstName,
                                 LastName = dc.LastName,
                                 Phone = dc.Phone,
                                 Email = dc.Email,
                                 DateOfBirth = dc.DateOfBirth,
                                 Gender = g.Cinsiyet
                             };

                return result.ToList();
            }
        }
    }
}

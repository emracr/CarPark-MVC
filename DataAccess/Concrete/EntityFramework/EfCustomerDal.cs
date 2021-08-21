using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarparkContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from c in context.Customers
                             join g in context.Genders
                             on c.Cinsiyet equals g.Id
                             select new CustomerDetailsDto()
                             {
                                 Id = c.Id,
                                 TC = c.TC,
                                 Ad = c.Ad,
                                 Soyad = c.Soyad,
                                 Telefon = c.Telefon,
                                 Email = c.Email,
                                 DogumTarihi = c.DogumTarihi,
                                 Cinsiyet = g.Cinsiyet
                             };

                return result.ToList();
            }
        }
    }
}

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
    public class EfTransactionLogDal : EfEntityRepositoryBase<TransactionLog, CarparkContext>, ITransactionLogDal
    {
        public List<TransactionLogDetailsDto> GetTransactionLogDetails()
        {
            using (CarparkContext context = new CarparkContext())
            {
                var result = from t in context.TransactionLogs
                             join c in context.Customers
                             on t.CustomerId equals c.Id
                             join tt in context.TransactionTypes
                             on t.TransactionNameId equals tt.Id
                             select new TransactionLogDetailsDto()
                             {
                                 Id = t.Id,
                                 TC = c.TC,
                                 FirstName = c.Ad,
                                 LastName = c.Soyad,
                                 TransactionTypeName = tt.TransactionName,
                                 DateOfTransaction = t.DateOfTransaction
                             };

                return result.ToList();
            }
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAcess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Concrete.Entity_Framework
{
    public class EfCustomerDal : IEntityRepositoryBase<Customer, CarRentalDbContext>, ICustomerDal
    {
    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}

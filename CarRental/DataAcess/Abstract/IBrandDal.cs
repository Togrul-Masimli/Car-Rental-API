using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
    }
}

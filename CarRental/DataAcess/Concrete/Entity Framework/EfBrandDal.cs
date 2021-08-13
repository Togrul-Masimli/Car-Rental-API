using DataAcess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAcess.Concrete.Entity_Framework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand Entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand Entity)
        {
            throw new NotImplementedException();
        }
    }
}

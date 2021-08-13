using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAcess.Abstract
{
    public interface IEntityRepositoryDal<T> where T: class,IEntity,new()
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}

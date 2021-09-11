using Core.DataAccess.EntityFramework;
using DataAcess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcess.Concrete.Entity_Framework
{
    public class EfCarImagesDal : IEntityRepositoryBase<CarImages, CarRentalDbContext>, ICarImagesDal
    {
    }
}

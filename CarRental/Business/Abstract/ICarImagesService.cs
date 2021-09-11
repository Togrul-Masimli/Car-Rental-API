using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IResult Add(CarImages carImage, IFormFile file, int carId);
        IResult Delete(CarImages carImage);
        IResult Update(CarImages carImage, IFormFile file);
    }
}

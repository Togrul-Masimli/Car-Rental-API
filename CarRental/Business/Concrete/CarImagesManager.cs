using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAcess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;
        public CarImagesManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(CarImages carImage, IFormFile file, int carId)
        {
            var imageResult = _fileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            carImage.ImagePath = imageResult.Message;
            carImage.AddedDate = DateTime.Now;
            carImage.CarId = carId;


            _carImagesDal.Add(carImage);

            return new SuccessResult("Image added");
        }

        public IResult Delete(CarImages carImage)
        {
            _carImagesDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IResult Update(CarImages carImage, IFormFile file)
        {
            _carImagesDal.Update(carImage);

            return new SuccessResult();
        }
    }
}

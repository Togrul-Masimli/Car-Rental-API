using Business.Concrete;
using DataAcess.Concrete.Entity_Framework;
using DataAcess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCarDetails();

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 70, ModelYear = 2007, Description = "E270 Diesel" });

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void TestCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.BrandName + "/ " + car.CarName + "/ " + car.ColorName + "/ " + car.DailyPrice);
            }
        }
    }
}

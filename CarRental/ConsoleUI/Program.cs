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



            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now.AddDays(-2) });

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

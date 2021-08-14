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

            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "/ " + car.CarName + "/ " + car.ColorName + "/ " + car.DailyPrice);
            }
        }
    }
}

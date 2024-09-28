using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var Car in carManager.GetByModelYear(2019,2022))
            {
                Console.WriteLine(Car.BrandId +" "+ Car.CarName +" "+ Car.ColorId +" "+ Car.DailyPrice +" "+ Car.Description);
            }


        }
    }
}

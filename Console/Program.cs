using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            

            JoinTest();



            //EfCarDal efCarDal = new EfCarDal();
            //efCarDal.Add(new Car { CarName = "C300", BrandId = 2, ColorId = 5, DailyPrice = 1250, ModelYear = 2020, Description = "Mercedes bietet luxuriöses Design und überlegene Ingenieurskunst." });
            //foreach (var car in efCarDal.GetAll())
            //{
            //    Console.WriteLine(car.BrandId + " " + car.CarName + " " + car.Description);

            //}


            // CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var Car in carManager.GetCarsByDailyPrice(0))
            //{
            //    Console.WriteLine(Car.BrandId +" "+ Car.CarName +" "+ Car.ColorId +" "+ Car.DailyPrice +" "+ Car.Description);
            //}




        }


        //BrandTest();

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}

        //JoinTest();
        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}

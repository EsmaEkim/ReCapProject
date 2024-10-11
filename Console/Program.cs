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
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            if (result.Success==true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.CarId + "/" + rental.CustomerId + "/" + rental.UserId);
                }

            }           

        }



        //DailyPriceTest();
        private static void DailyPriceTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            decimal minPrice = 100;
            decimal maxPrice = 1000;
            var result = carManager.GetCarsByDailyPrice(minPrice, maxPrice);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.DailyPrice);
                }
            }
        }

        //CarAddTest();
        private static void CarAddTest()
        {
            EfCarDal efcardal = new EfCarDal();
            efcardal.Add(new Car { CarName = "C300", BrandId = 2, ColorId = 5, DailyPrice = 1250, ModelYear = 2020, Description = "Mercedes bietet luxuriöses design und überlegene Ingenieurskunst." });
            foreach (var car in efcardal.GetAll())
            {
                Console.WriteLine(car.BrandId + " " + car.CarName + " " + car.Description);

            }
        }


        //UserDetailTest();
        private static void UserDetailTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserDetails();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + "/" + user.LastName + "/" + user.CompanyName);
                }

            }
        }


        //BrandTest();

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
        }

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

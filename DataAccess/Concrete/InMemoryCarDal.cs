using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : InMemory
    {
        List<Color> _colors;
        List<Brand> _brands;    
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=1500, ModelYear=2015,BrandName="Mercedes: ", Description="Mercedes bietet luxuriöses Design und überlegene Ingenieurskunst.", },
                new Car{CarId=2, BrandId=3, ColorId=4, DailyPrice=800, ModelYear=2019,BrandName="BMW: ", Description="BMW vereint sportliches Fahren mit innovativer Technik " },
                new Car{CarId=3, BrandId=1, ColorId=2, DailyPrice=1600, ModelYear=2020,BrandName="Mercedes: ", Description="Mercedes bietet luxuriöses Design und überlegene Ingenieurskunst." },
                new Car{CarId=4, BrandId=2, ColorId=3, DailyPrice=1200, ModelYear=2020,BrandName="Audi: ", Description="Audi zeichnet sich durch innovative Technik und dynamisches Design aus." }
            };

            _brands = new List<Brand>
            {
                new Brand{BrandId=1, BrandName="Mercedes"},
                new Brand{BrandId=2, BrandName="Audi"},
                new Brand{BrandId=3, BrandName="BMW"},

            };

            _colors = new List<Color>
            {
                new Color{ColorId=1, ColorName="Grau"},
                new Color{ColorId=2, ColorName="Schwarz"},
                new Color{ColorId=3, ColorName="Weiß"},
                new Color{ColorId=4, ColorName="Dunkelblau"},
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        
    }
}

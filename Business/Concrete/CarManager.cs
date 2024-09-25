using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        InMemory _ınMemory;
        public CarManager(InMemory ınMemory)
        {
            _ınMemory = ınMemory;
        }
        public List<Car> GetAll()
        {
            //Jobcodes
            //z.B gibt es eine Berechtigung?
            return _ınMemory.GetAll();
        }
    }
}

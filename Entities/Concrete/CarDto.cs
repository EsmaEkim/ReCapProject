using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarDto:IEntity
    {
        public string BrandName { get; set; }
        public int CarId { get; set; }
        public string ColorName { get; set; }
        public int ColorId { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
    }
}

﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;                
                context.SaveChanges();

                
            }
        }

        public void Delete(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context=new CarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using(CarContext context=new CarContext())
            {
                return filter == null ? context.Set<Car>().ToList()
                                      : context.Set<Car>().Where(filter).ToList();

               

            }
        }

        public void Update(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var carToUpdate = context.Cars.SingleOrDefault(c => c.CarId == entity.CarId);
                carToUpdate.CarName = entity.CarName;
                carToUpdate.BrandId = entity.BrandId;
                carToUpdate.ColorId = entity.ColorId;
                carToUpdate.DailyPrice = entity.DailyPrice;
                carToUpdate.Description = entity.Description;
                context.SaveChanges();
            }

            //var updatedEntity = context.Entry(entity);
            //updatedEntity.State = EntityState.Modified;
            //context.SaveChanges();
        }
    }
}
﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class CarContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-F1UVV3S\SQLEXPRESS;Database=carmaster;Trusted_Connection=true" );
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        
    }
}
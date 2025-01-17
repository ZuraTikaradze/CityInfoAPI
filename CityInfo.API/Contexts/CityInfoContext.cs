﻿using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Contexts
{
    public class CityInfoContext: DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<PointsOfInterest> PointsOfInterests { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options) 
        {
         
        }

    }
}

﻿using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Repositories
{
    public interface ICityInfoRepository
    {
       IEnumerable<City> GetCities();
       City GetCity(int cityId);
    }
}

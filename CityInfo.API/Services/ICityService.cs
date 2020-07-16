using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityService
    {
        GetCitiesOutput GetCities();
        GetCityOutput GetCity(int cityId);
    }
}
//List<CityWithoutPointsOfInterestsDTO> GetCities();
//CityDTO GetCity(int cityId);
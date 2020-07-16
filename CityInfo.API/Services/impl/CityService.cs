using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Models.City;
using CityInfo.API.Models.PointsOfInterest;
using CityInfo.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services.impl
{
    public class CityService : ICityService
    {
        private ICityInfoRepository _cityInfoRepository;

        public CityService(ICityInfoRepository cityInfoRepository) 
        {
            _cityInfoRepository = cityInfoRepository;
        }

        public GetCitiesOutput GetCities()
        {

            var cities = _cityInfoRepository.GetCities();

            GetCitiesOutput getCitiesOutput = new GetCitiesOutput();
            

            foreach (City city in cities)
            {
                getCitiesOutput.cityDTOs.Add(new CityDTO
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name
                });
            }
            return getCitiesOutput;
        }

        public GetCityOutput GetCity(int cityId)
        {
            var city = _cityInfoRepository.GetCity(cityId);

            GetCityOutput getCityOutput = new GetCityOutput()
            {
                Id = city.Id,
                Name = city.Name,
                Description = city.Description
            };


            foreach (var poi in city.PointsOfInterest)
            {
                getCityOutput.PointsOfInterest.Add(
                    new PointsOfInterestDTO()
                    {
                        Id = poi.Id,
                        Name = poi.Name,
                        Description = poi.Description
                    });
            }

            return getCityOutput;

        }
    }
}

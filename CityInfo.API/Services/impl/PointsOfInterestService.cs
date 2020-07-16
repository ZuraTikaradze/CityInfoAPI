using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Models.PointsOfInterest;
using CityInfo.API.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services.impl
{
    public class PointsOfInterestService : IPointsOfInterestService
    {
        private IPointsOfInterestRepository _pointsOfInterestRepository;
        private ILogger<PointsOfInterestService> _logger;

        public PointsOfInterestService(IPointsOfInterestRepository pointsOfInterestRepository, ILogger<PointsOfInterestService> logger) 
        {
            _pointsOfInterestRepository = pointsOfInterestRepository;
            _logger = logger;
        }
        public void CreatePointOfInterest(CreatePointOfInterestInput createPointOfInterestInput)
        {
            var finalPointOfInterest = new PointsOfInterest()
            {
                Name = createPointOfInterestInput.Name,
                Description = createPointOfInterestInput.Description
            };
            _pointsOfInterestRepository.AddPointOfInterestForCity(createPointOfInterestInput.cityId, finalPointOfInterest);
            _pointsOfInterestRepository.Save();

            _logger.LogInformation("CreatePointOfInterest - PointOfInterest-ი წარმატებით შექიმნა ");
        }

        public void DeletePointOfInterest(int cityId, int id)
        {
            var pointsOfInterestEntity = _pointsOfInterestRepository.GetPointOfInterestForCity(cityId, id);
            _pointsOfInterestRepository.DeletePointOfInterest(pointsOfInterestEntity);
            _pointsOfInterestRepository.Save();

            _logger.LogInformation("DeletePointOfInterest - ქალაქზე "+ cityId + " PointOfInterest -ი "+ id+ "წარმატებით წაიშალა");
        }

        public GetPointOfInterestForCityOutput GetPointOfInterestForCity(int cityId, int pointsOfInterestId)
        {
            var pointOfInterest = _pointsOfInterestRepository.GetPointOfInterestForCity(cityId, pointsOfInterestId);

            GetPointOfInterestForCityOutput getPointOfInterestForCityOutput = new GetPointOfInterestForCityOutput();
            getPointOfInterestForCityOutput.pointsOfInterestDTO.Id = pointOfInterest.Id;
            getPointOfInterestForCityOutput.pointsOfInterestDTO.Name = pointOfInterest.Name;
            getPointOfInterestForCityOutput.pointsOfInterestDTO.Description = pointOfInterest.Description;


            return getPointOfInterestForCityOutput;
        }

        public GetPointsOfInterestsForCityOutput GetPointsOfInterestsForCity(int cityId)
        {
            var pointsOfInterestForCity = _pointsOfInterestRepository.GetPointsOfInterestsForCity(cityId);

            var getPointsOfInterestsForCityOutput = new GetPointsOfInterestsForCityOutput();
            foreach (var poi in pointsOfInterestForCity)
            {
                getPointsOfInterestsForCityOutput.pointsOfInterestDTOs.Add(new PointsOfInterestDTO()
                {
                    Id = poi.Id,
                    Name = poi.Name,
                    Description = poi.Description
                });

            }

            return getPointsOfInterestsForCityOutput;
        }
    }
}

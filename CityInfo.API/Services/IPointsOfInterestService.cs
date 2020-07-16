using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Models.PointsOfInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface IPointsOfInterestService
    {
        GetPointsOfInterestsForCityOutput GetPointsOfInterestsForCity(int cityId);
        GetPointOfInterestForCityOutput GetPointOfInterestForCity(int cityId, int pointsOfInterestId);

        void CreatePointOfInterest(CreatePointOfInterestInput createPointOfInterestInput);

        void DeletePointOfInterest(int cityId, int id);
    }
}

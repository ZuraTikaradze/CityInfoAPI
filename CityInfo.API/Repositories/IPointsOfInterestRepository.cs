using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Repositories
{
   public interface IPointsOfInterestRepository
    {
        IEnumerable<PointsOfInterest> GetPointsOfInterestsForCity(int cityId);
        PointsOfInterest GetPointOfInterestForCity(int cityId, int pointsOfInterestId);

        void AddPointOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest);

        void DeletePointOfInterest(PointsOfInterest pointsOfInterest);

        bool Save();
    }
}

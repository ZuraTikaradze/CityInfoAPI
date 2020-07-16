using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Repositories
{
    public class PointsOfInterestRepository : IPointsOfInterestRepository
    {

        private CityInfoContext _context;

        public PointsOfInterestRepository(CityInfoContext context) {
            _context = context;
        }



        public PointsOfInterest GetPointOfInterestForCity(int cityId, int pointsOfInterestId)
        {
            return _context.PointsOfInterests.Where(p => p.city.Id == cityId && p.Id == pointsOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterestsForCity(int cityId)
        {
            return _context.PointsOfInterests.Where(p => p.city.Id == cityId).ToList();
        }

        public void AddPointOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest)
        {
           var city = _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
           city.PointsOfInterest.Add(pointsOfInterest);

        }

        public void DeletePointOfInterest(PointsOfInterest pointsOfInterest)
        {
            _context.PointsOfInterests.Remove(pointsOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models.PointsOfInterest
{
    public class GetPointsOfInterestsForCityOutput
    {
        public List<PointsOfInterestDTO> pointsOfInterestDTOs { get; set; } = new List<PointsOfInterestDTO>();
    }
}

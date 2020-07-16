using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models.PointsOfInterest
{
    public class GetPointOfInterestForCityOutput
    {
        public PointsOfInterestDTO pointsOfInterestDTO { get; set; } = new PointsOfInterestDTO();
    }
}

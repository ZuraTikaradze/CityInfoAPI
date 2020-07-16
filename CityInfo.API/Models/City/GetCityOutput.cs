using CityInfo.API.Models.PointsOfInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models.City
{
    public class GetCityOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PointsOfInterestDTO> PointsOfInterest { get; set; } = new List<PointsOfInterestDTO>();
    }
}

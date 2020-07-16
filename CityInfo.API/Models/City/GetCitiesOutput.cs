


using System.Collections.Generic;

namespace CityInfo.API.Models.City
{
    public class GetCitiesOutput
    {
        public List<CityDTO> cityDTOs { get; set; } = new List<CityDTO>();
    }
}

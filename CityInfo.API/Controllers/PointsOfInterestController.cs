using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Models.PointsOfInterest;
using CityInfo.API.Repositories;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]  
    public class PointsOfInterestController : ControllerBase
    {
        private IPointsOfInterestService _pointsOfInterestService;

        public PointsOfInterestController( IPointsOfInterestService pointsOfInterestService)
        {
            _pointsOfInterestService = pointsOfInterestService;
        }


        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            return Ok(_pointsOfInterestService.GetPointsOfInterestsForCity(cityId));
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            return Ok(_pointsOfInterestService.GetPointOfInterestForCity(cityId,id));
        }

        [HttpPost]
        public IActionResult CreatePointOfInterest([FromBody] CreatePointOfInterestInput createPointOfInterestInput)
        {
            _pointsOfInterestService.CreatePointOfInterest(createPointOfInterestInput);
            return Ok();
        }


        //[HttpPut("{id}")]
        //public IActionResult UpdatePointOfInterest(int cityId, int id,
        //  [FromBody] PointsOfInterestUpdateDTO pointsOfInterestUpdateDTO)
        //{
        //    // nope
        //    return Ok();
        //}

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {

            _pointsOfInterestService.DeletePointOfInterest(cityId, id);
            return NoContent();
        }

}
}
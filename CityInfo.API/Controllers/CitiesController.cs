using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Repositories;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class CitiesController : ControllerBase
    {

        private ICityService _cityService;

        public CitiesController( ICityService cityService ) 
        {
            _cityService = cityService;
        }


        [HttpGet("cities")]
        public IActionResult GetCities() {
            return Ok(_cityService.GetCities());
        }


        [HttpGet("cities/{id}")]
        public IActionResult GetCity(int id)
        {
            return Ok(_cityService.GetCity(id));
        }
    }
}

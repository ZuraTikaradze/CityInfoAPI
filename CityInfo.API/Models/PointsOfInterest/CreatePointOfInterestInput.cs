﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models.PointsOfInterest
{
    public class CreatePointOfInterestInput
    {
        public int cityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       
    }
}

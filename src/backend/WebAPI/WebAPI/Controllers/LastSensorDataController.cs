using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace WebAPI
{
    //API endpoints
    [Route("api/lastsensor")]
    public class LastSensorDataController : ControllerBase
    {
        private LastSensorDataService _service;

        public LastSensorDataController(LastSensorDataService service)
        {
            _service = service;
        }

        [HttpGet("{id}")] // GET api/lastsensor/5  sensor id
        public LastSensorData Get(int id, int count)
        {
           return _service.Get(id, count);          
        }

    }
}

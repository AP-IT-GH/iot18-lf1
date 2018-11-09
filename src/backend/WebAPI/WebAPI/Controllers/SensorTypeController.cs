using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Repositories;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    //API endpoints
    [Route("api/v1/sensortype")]
    public class SensorTypecontroller : Controller
    {
        private SensorTypeService _service;

        public SensorTypecontroller(SensorTypeService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/sensor
        public IEnumerable<SensorType> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public SensorType Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public SensorType Put([FromBody]SensorType type)
        {
            return _service.Update(type);
        }

        [HttpPost]
        public SensorType Post([FromBody]SensorType type)
        {
            return _service.Create(type);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
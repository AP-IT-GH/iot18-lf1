using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Services;

namespace WebAPI
{
    //API endpoints
    [Route("api/v1/sensordata")]
    public class SensorDataController : ControllerBase
    {
        private SensorDataService _service;

        public SensorDataController(SensorDataService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/sensordata
        public IEnumerable<SensorData> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] // GET api/sensordata/5
        public SensorData Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public SensorData Put([FromBody]SensorData data)
        {
            return _service.Update(data);
        }

        [HttpPost]
        public SensorData Post([FromBody]SensorData data)
        {
            return _service.Create(data);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
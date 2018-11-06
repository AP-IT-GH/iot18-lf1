using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;

namespace WebAPI
{
    //API endpoints
    [Route("api/v1/sensor")]
    public class SensorController : ControllerBase
    {
        private SensorService _service;

        public SensorController(SensorService service)
        {
            _service = service;
        }

        [HttpGet] 
        public IEnumerable<Sensor> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] 
        public Sensor Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public Sensor Put([FromBody]Sensor sensor)
        {
            return _service.Update(sensor);
        }

        [HttpPost]
        public Sensor Post([FromBody]Sensor sensor)
        {
            return _service.Create(sensor);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }


    }
}

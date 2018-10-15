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
    [Route("api/sensor")]
    public class SensorController : ControllerBase
    {
        private SensorService _service;

        public SensorController(SensorService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/sensor
        public IEnumerable<SensorModel> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] // GET api/sensor/5
        public SensorModel Get(long id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public SensorModel Put([FromBody]SensorModel sensor)
        {
            return _service.Update(sensor);
        }

        [HttpPost]
        public SensorModel Post([FromBody]SensorModel sensor)
        {
            return _service.Create(sensor);
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            return _service.Delete(id);
        }


    }
}

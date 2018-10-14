using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/Sensor")] // /api/Sensor
    public class SensorController : ControllerBase
    {
        private readonly CollectionContext _context;

        public SensorController(CollectionContext context)
        {
            _context = context;

        }

        [HttpGet] // /api/Sensor
        public List<Sensor> GetAll()
        {
            return _context.Sensors.Include(d =>d.SensorType)
                                   .ToList();
        }

        [Route("{id}")] // /api/Sensor/2
        [HttpGet]
        public ActionResult GetById(int id)
        {
            //var item = _context.Sensors.Find(id);
            var item = _context.Sensors.Include( d => d.SensorType)
                                    .SingleOrDefault(d => d.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")] // /api/Sensor/2 + body
        public IActionResult Update(int id, Sensor item)
        {
            var sensor = _context.Sensors.Find(id);
            if (sensor == null)
            {
                return NotFound();
            }

            sensor.SensorType =item.SensorType;
            sensor.LabFarm = item.LabFarm;
            sensor.TimeStamp = item.TimeStamp;
            sensor.Value = item.Value;

            _context.Sensors.Update(sensor);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPost] // /api/Sensor + body
        public IActionResult Post([FromBody] Sensor Sensor)
        {
            _context.Sensors.Add(Sensor);
            _context.SaveChanges();
            return Created("", Sensor);
        }

        [HttpDelete("{id}")] // /api/Sensor/2
        public IActionResult Delete(int id)
        {
            var Sensor = _context.Sensors.Find(id);
            if (Sensor == null)
            {
                return NotFound();
            }

            _context.Sensors.Remove(Sensor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
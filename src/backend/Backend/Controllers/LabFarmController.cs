using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    [Route("api/LabFarm")] // /api/LabFarm
    public class LabFarmController : ControllerBase
    {
        private readonly CollectionContext _context;

        public LabFarmController(CollectionContext context)
        {
            _context = context;
        }

        [HttpGet] // /api/LabFarm
        public List<LabFarm> GetAll()
        {
            return _context.LabFarms.ToList();
        }

        [Route("{id}")] // /api/LabFarm/1
        [HttpGet]
        public ActionResult GetById(int id)
        {
            var item = _context.LabFarms.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")] // /api/LabFarm/1 + body
        public IActionResult Update(int id, LabFarm item)
        {
            var labFarm = _context.LabFarms.Find(id);
            if (labFarm == null)
            {
                return NotFound();
            }

            labFarm.AuthId =item.AuthId;
            //***TODO */



            

            _context.LabFarms.Update(labFarm);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPost] // /api/LabFarm + body
        public IActionResult Post([FromBody] LabFarm LabFarm)
        {
            _context.LabFarms.Add(LabFarm);
            _context.SaveChanges();
            return Created("", LabFarm);
        }

        [HttpDelete("{id}")] // /api/LabFarm/1
        public IActionResult Delete(int id)
        {
            var LabFarm = _context.LabFarms.Find(id);
            if (LabFarm == null)
            {
                return NotFound();
            }

            _context.LabFarms.Remove(LabFarm);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
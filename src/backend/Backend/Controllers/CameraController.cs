using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    [Route("api/camera")] // /api/camera
    public class cameraController : ControllerBase
    {
        private readonly CollectionContext _context;

        public cameraController(CollectionContext context)
        {
            _context = context;

        }

        [HttpGet] // /api/camera
        public List<Camera> GetAll()
        {
            return _context.Cameras.ToList();
        }

        [Route("{id}")] // /api/camera/2
        [HttpGet]
        public ActionResult GetById(int id)
        {
            var item = _context.Cameras.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut("{id}")] // /api/camera/2 + body
        public IActionResult Update(int id, Camera item)
        {
            var camera = _context.Cameras.Find(id);
            if (camera == null)
            {
                return NotFound();
            }

            camera.Column =item.Column;

            //cameraOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO

            _context.Cameras.Update(camera);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPost] // /api/camera + body
        public IActionResult Post([FromBody] Camera camera)
        {
            _context.Cameras.Add(camera);
            _context.SaveChanges();
            return Created("", camera);
        }

        [HttpDelete("{id}")] // /api/camera/2
        public IActionResult Delete(int id)
        {
            var camera = _context.Cameras.Find(id);
            if (camera == null)
            {
                return NotFound();
            }

            _context.Cameras.Remove(camera);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
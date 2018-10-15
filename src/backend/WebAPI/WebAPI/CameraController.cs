using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Services;

namespace WebAPI
{
    //API endpoints
    [Route("api/camera")]
    public class CameraController : ControllerBase
    {
        private CameraService _service;

        public CameraController(CameraService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/camera
        public IEnumerable<CameraModel> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] // GET api/camera/5
        public CameraModel Get(long id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public CameraModel Put([FromBody]CameraModel camera)
        {
            return _service.Update(camera);
        }

        [HttpPost]
        public CameraModel Post([FromBody]CameraModel camera)
        {
            return _service.Create(camera);
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            return _service.Delete(id);
        }


    }
}

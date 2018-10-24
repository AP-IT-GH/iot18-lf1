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
    [Route("api/picture")]
    public class PictureController : ControllerBase
    {
        private PictureService _service;

        public PictureController(PictureService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/sensor
        public IEnumerable<PictureModel> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] // GET api/picture/5
        public PictureModel Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public PictureModel Put([FromBody]PictureModel picture)
        {
            return _service.Update(picture);
        }

        [HttpPost]
        public PictureModel Post([FromBody]PictureModel picture)
        {
            return _service.Create(picture);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
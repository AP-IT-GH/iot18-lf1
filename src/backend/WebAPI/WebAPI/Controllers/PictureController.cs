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
    [Route("api/v1/picture")]
    public class PictureController : Controller
    {
        private PictureService _service;

        public PictureController(PictureService service)
        {
            _service = service;
        }

        [HttpGet] // GET api/sensor
        public IEnumerable<Picture> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")] 
        public Picture Get(int id)
        {
            return _service.Get(id);
        }

        [HttpPut("{id}")]
        public Picture Put([FromBody]Picture picture)
        {
            return _service.Update(picture);
        }

        [HttpPost]
        public Picture Post([FromBody]Picture picture)
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
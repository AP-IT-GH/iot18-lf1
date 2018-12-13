using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Services;
using System.Linq;
using System;

namespace WebAPI
{
    //API endpoints
    [Route("api/v1/plant")]
    public class PlantController : Controller
    {
        private PlantService _plantService;
        private PictureService _pictureService;

        public PlantController(PlantService plantService, PictureService pictureService)
        {
            _plantService = plantService;
            _pictureService = pictureService;
        }

        [HttpGet] 
        public IEnumerable<Plant> Get()
        {
            return _plantService.GetAll();
        }

        [Route("{id}")] 
        [HttpGet]
        public Plant Get(int id)
        {
            return _plantService.Get(id);
        }

        [Route("{id}/pictures")]
        [HttpGet]
        public List<Picture> GetCameraPictures(int id,DateTime startDate,int hours = 24,int page = 1, int pageSize = 24)
        {
            DateTime endDate = startDate.AddHours(hours);
            
            return _plantService.Get(id).Pictures.Where( x=> x.TimeStamp >= startDate).Where(x => x.TimeStamp <= endDate).Skip((page-1)*pageSize).Take(pageSize).ToList();
            

        }

        [HttpPut("{id}")]
        public Plant Put([FromBody]Plant plant)
        {
            return _plantService.Update(plant);
        }

        [HttpPost]
        public Plant Post([FromBody]Plant camera)
        {
            return _plantService.Create(camera);
        }


        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _plantService.Delete(id);
        }


    }
}

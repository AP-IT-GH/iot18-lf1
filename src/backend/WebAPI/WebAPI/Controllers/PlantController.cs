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
        public List<Picture> GetCameraPictures(int id,int? skip, int? take)
        {
            if(skip == null || take == null)
            {
                return _plantService.Get(id).Pictures.ToList();
            }
            else
            {
                var _skip = Convert.ToInt32(skip);
                var _take = Convert.ToInt32(take);
                return _plantService.Get(id).Pictures.Skip(_skip).Take(_take).ToList();
            }

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

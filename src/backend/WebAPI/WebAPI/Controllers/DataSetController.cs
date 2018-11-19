using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;

namespace WebAPI.Controllers
{
    //API endpoints
    [Route("api/v1/dataset")]
    public class DataSetController : Controller
    {
        private DataSetService _dataSetService;

        public DataSetController(DataSetService dataSetService)
        {
            _dataSetService = dataSetService;
        }

        [HttpGet]
        public IEnumerable<PlantDataSet> Get()
        {
            return _dataSetService.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public PlantDataSet Get(int id)
        {
            return _dataSetService.Get(id);
        }

        [Route("names")]
        [HttpGet]
        public List<string> GetName()
        {
            return _dataSetService.GetPlants();
        }

        [HttpPut("{id}")]
        public PlantDataSet Put([FromBody]PlantDataSet dataSet)
        {
            return _dataSetService.Update(dataSet);
        }

        [HttpPost]
        public PlantDataSet Post([FromBody]PlantDataSet dataSet)
        {
            return _dataSetService.Create(dataSet);
        }


        [Route("{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _dataSetService.Delete(id);
        }


    }

}

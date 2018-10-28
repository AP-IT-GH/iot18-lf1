using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using ViewModels;

namespace WebAPI
{
    //API endpoints
    [Route("api/v1/labfarm")]
    public class LabFarmController : Controller
    {
        private LabFarmService _labfarmService;
        private PlantService _plantService;
        private SensorService _sensorService;
        private SensorDataService _sensorDataService;
        private PictureService _pictureService;

        public LabFarmController(LabFarmService labfarmService, PlantService plantService, SensorService sensorService, SensorDataService sensorDataService, PictureService pictureService)
        {
            _labfarmService = labfarmService;
            _plantService = plantService;
            _sensorService = sensorService;
            _sensorDataService = sensorDataService;
            _pictureService = pictureService;
        }

        [HttpGet("{id:int}")] 
        public LabFarm Get(int id)
        {
            return _labfarmService.GetById(id);
        }

        [HttpGet("{name?}")]  
        public List<LabFarm> Get(string name,string authorId )
        {
            return _labfarmService.GetList(name, authorId);
        }


        [HttpPut("{id}")]
        public LabFarm Put([FromBody]LabFarm labfarm,int id)
        {
            return _labfarmService.Update(labfarm,id);
        }

        [HttpPost]
        public LabFarm Post([FromBody]LabFarm labfarm)
        {
            return _labfarmService.Create(labfarm);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _labfarmService.Delete(id);
        }

        [HttpGet("{name}/plants")]
        public List<Plant> GetPlants(string name)
        {
            return _labfarmService.GetByName(name).Plants.ToList();
        }

        [HttpGet("{name}/plants/pictures")]
        public List<LastPictures> GetPlants(string name, int count)
        {
            return _plantService.GetLastPictures(name, count);
        }

        [HttpPost("{name}/plants")]
        public Plant PostCamera([FromBody]Plant plant, string name)
        {
            plant.Labfarm = _labfarmService.GetByName(name);
            return _plantService.Create(plant);
        }

        [HttpGet("{name}/plants/{plantName}")]
        public List<Plant> GetPlant(string name, string plantName)
        {
            return _labfarmService.GetPlant(name, plantName);
        }

        [HttpPost("{name}/plants/{plantName}/pictures")]
        public Picture PostPicture([FromBody]Picture picture, string name, string plantName)
        {
            picture.Plant = _labfarmService.GetPlant(name, plantName)[0]; //TODO bad code?
            return _pictureService.Create(picture);
        }

        [HttpGet("{name}/sensors")]
        public List<Sensor> GetSensors(string name)
        {
            return _labfarmService.GetByName(name).Sensors.ToList();
        }

        [HttpGet("{name}/sensors/values")]
        public List<LastSensorValues> GetSensors(string name, int count)
        {
            return _sensorService.GetLastValues(name, count);
        }

        [HttpPost("{name}/sensors")]
        public Sensor PostSensor([FromBody]Sensor sensor, string name)
        {
            sensor.LabFarm = _labfarmService.GetByName(name);
            return _sensorService.Create(sensor);
        }
        [HttpGet("{name}/sensors/{sensorName}")]
        public List<Sensor> GetSensor(string name, string sensorName)
        {
            return _labfarmService.GetSensor(name, sensorName);
        }

        [HttpPost("{name}/sensors/{sensorName}/data")]
        public SensorData PostSensorData([FromBody]SensorData data, string name, string sensorName)
        {
            data.Sensor = _labfarmService.GetSensor(name, sensorName)[0]; // TODO bad code?
            return _sensorDataService.Create(data);
        }


    }
}

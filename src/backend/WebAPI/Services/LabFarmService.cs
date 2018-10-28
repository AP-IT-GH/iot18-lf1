using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    //Bussines logic
    public class LabFarmService
    {
        private LabFarmRepository _labfarmRepository;
        private PlantRepository _plantRepository;
        private SensorRepository _sensorRepository;

        public LabFarmService(LabFarmRepository labfarmRepository, PlantRepository plantRepository, SensorRepository sensorRepository)
        {
            _labfarmRepository = labfarmRepository;
            _plantRepository = plantRepository;
            _sensorRepository = sensorRepository;
        }

        public LabFarm Create(LabFarm labfarm)
        {
            return _labfarmRepository.Post(labfarm);
        }

        public LabFarm Update(LabFarm labfarm, int id)
        {
            if(labfarm.Id == 0)
            {
                labfarm.Id = id;
            }
            return _labfarmRepository.Put(labfarm);
        }

        public bool Delete(int id)
        {
            return _labfarmRepository.Delete(id);
        }

        public List<LabFarm> GetList(string name,string authId = "")
        {

            if (authId != null && name == null)
            {
                var labfarm1 = from s in _labfarmRepository.GetAll()
                              where s.AuthId == authId
                              select s;
                return labfarm1.ToList();
            }
            else if (authId == null && name != null)
            {
                var labfarm2 = from s in _labfarmRepository.GetAll()
                              where s.Name == name
                              select s;
                return labfarm2.ToList();
            }
            else
            {
                return _labfarmRepository.GetAll();
            }
       
        }

        public LabFarm GetById(int id)
        {         
             return _labfarmRepository.Get(id);
        }

        public LabFarm GetByName(string name)
        {
            var labfarm = from s in _labfarmRepository.GetAll()
                          where s.Name == name
                          select s;
            return labfarm.ToList()[0]; //TODO bad code???
        }

        public List<Plant> GetPlant(string name, string plantName)
        {
            var plants = GetByName(name).Plants.ToList();
            var plant = from s in plants
                        where s.Name == plantName
                        select s;
            return plant.ToList();
        }
        
        public List<Sensor> GetSensor(string name, string sensorName)
        {
            var sensors = GetByName(name).Sensors.ToList();
            var sensor = from s in sensors
                         where s.Name == sensorName
                         select s;
            return sensor.ToList();
        }


    }
}

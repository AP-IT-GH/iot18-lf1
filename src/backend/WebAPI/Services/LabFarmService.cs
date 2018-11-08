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

        public List<LabFarm> GetList(string authId = "")
        {

            if (authId != "")
            {
                var labfarms = from s in _labfarmRepository.GetAll()
                              where s.AuthId == authId
                              select s;
               
                return GetLatetsValues(labfarms.ToList()).ToList();
            }
            else
            {
                return GetLatetsValues(_labfarmRepository.GetAll());
            }
       
        }

        public LabFarm GetById(int id)
        {         
             return _labfarmRepository.Get(id);
        }


        public List<Plant> GetPlant(int  id, string plantName)
        {
            var plants = GetById(id).Plants.ToList();
            var plant = from s in plants
                        where s.Name == plantName
                        select s;
            return plant.ToList();
        }
        
        public List<Sensor> GetSensor(int id, string sensorName)
        {
            var sensors = GetById(id).Sensors.ToList();
            var sensor = from s in sensors
                         where s.Name == sensorName
                         select s;
            return sensor.ToList();
        }

        public List<LabFarm> GetLatetsValues(List<LabFarm> labfarms)
        {
            foreach (LabFarm l in labfarms)
            {
                foreach (Plant p in l.Plants)
                {
                    var pictures = p.Pictures.OrderByDescending(x => x.TimeStamp.TimeOfDay)
                                                .ThenBy(x => x.TimeStamp.Date)
                                                    .ThenBy(x => x.TimeStamp.Year)
                                                        .ToList();
                    var picture = pictures[0]; // get latest picture
                    p.Pictures.Clear();
                    p.Pictures.Add(picture);

                }

                foreach(Sensor s in l.Sensors)
                {
                    var values = s.SensorValues.OrderByDescending(x => x.TimeStamp.TimeOfDay)
                                                .ThenBy(x => x.TimeStamp.Date)
                                                    .ThenBy(x => x.TimeStamp.Year)
                                                        .ToList();
                    var value = values[0];
                    s.SensorValues.Clear();
                    s.SensorValues.Add(value);
                }
            }

            return labfarms;
        }

    }
}

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
        private SensorTypeRepository _sensorTypeRepository;
        private SensorRepository _sensorRepository;

        public LabFarmService(LabFarmRepository labfarmRepository, SensorTypeRepository sensorTypeRepository, SensorRepository sensorRepository)
        {
            _labfarmRepository = labfarmRepository;
            _sensorTypeRepository = sensorTypeRepository;
            _sensorRepository = sensorRepository;
        }

        public LabFarm Create(LabFarm labfarm)
        {
            InitializeSensors(_labfarmRepository.Post(labfarm));
            return _labfarmRepository.Get(labfarm.Id);
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
        
        public List<Sensor> GetSensorByName(int id, string sensorName)
        {
            var sensors = GetById(id).Sensors.ToList();
            var sensor = from s in sensors
                         where s.Name == sensorName
                         select s;
            return sensor.ToList();
        }
        public Sensor GetSensorById(int id1, int id2) //TODO bad code?
        {
            return _sensorRepository.Get(id2);
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

        public void InitializeSensors(LabFarm _labfarm)
        {
            var types = _sensorTypeRepository.GetAll();
            for (int i = 0; i < types.Count; i++)
            {
                var sensor = new Sensor()
                {
                    Name = "Sensor" + i,
                    SensorType = types[i],
                    LabFarmId = _labfarm.Id
                };

                _sensorRepository.Post(sensor);
            };
        }

    }
}

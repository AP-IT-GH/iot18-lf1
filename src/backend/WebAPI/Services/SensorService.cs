using System;
using System.Collections.Generic;
using System.Text;
using Repositories;
using Models;

namespace Services
{
    //Bussines logic
    public class SensorService
    {
        private SensorRepository _sensorRepository;
        private LabFarmRepository _labFarmRepository;

        public SensorService(SensorRepository sensorRepository, LabFarmRepository labFarmRepository)
        {
            _sensorRepository = sensorRepository;
            _labFarmRepository = labFarmRepository;
        }

        public SensorModel Create(SensorModel sensor)
        {
            sensor.LabFarm = _labFarmRepository.Get(sensor.LabFarmId);
            return _sensorRepository.Post(sensor);
        }

        public SensorModel Update(SensorModel sensor)
        {
            sensor.LabFarm = _labFarmRepository.Get(sensor.LabFarmId);
            return _sensorRepository.Put(sensor);
        }

        public bool Delete(int id)
        {
            return _sensorRepository.Delete(id);
        }

        public List<SensorModel> GetAll()
        {
            return _sensorRepository.GetAll();
        }

        public SensorModel Get(int id)
        {
            return _sensorRepository.Get(id);
        }

    }
}

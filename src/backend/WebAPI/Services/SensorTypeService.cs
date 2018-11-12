using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;

namespace Services
{
    public class SensorTypeService
    {
        private SensorTypeRepository _sensorTypeRepository;

        public SensorTypeService(SensorTypeRepository sensorTypeRepository)
        {
            _sensorTypeRepository = sensorTypeRepository;
        }

        public SensorType Create(SensorType type)
        {
            return _sensorTypeRepository.Post(type);
        }

        public SensorType Update(SensorType type)
        {
            return _sensorTypeRepository.Put(type);
        }

        public bool Delete(int id)
        {
            return _sensorTypeRepository.Delete(id);
        }

        public List<SensorType> GetAll()
        {
            return _sensorTypeRepository.GetAll();
        }

        public SensorType Get(int id)
        {
            return _sensorTypeRepository.Get(id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repositories;
using Services;

namespace Services
{
    public class SensorDataService
    {

        private SensorDataRepository _sensorDataRepository;

        public SensorDataService(SensorDataRepository sensorDataRepository )
        {
            _sensorDataRepository = sensorDataRepository;
        }

        public SensorData Create(SensorData data)
        {
            data.TimeStamp = DateTime.Now;
            return _sensorDataRepository.Post(data);
        }

        public SensorData Update(SensorData data)
        {
            return _sensorDataRepository.Put(data);
        }

        public bool Delete(int id)
        {
            return _sensorDataRepository.Delete(id);
        }

        public List<SensorData> GetAll()
        {
            return _sensorDataRepository.GetAll();
        }

        public SensorData Get(int id)
        {
            return _sensorDataRepository.Get(id);
        }

    }
}

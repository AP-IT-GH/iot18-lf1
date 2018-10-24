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
        private SensorRepository _sensorRepository;

        public SensorDataService(SensorDataRepository sensorDataRepository, SensorRepository sensorRepository)
        {
            _sensorDataRepository = sensorDataRepository;
            _sensorRepository = sensorRepository;
        }

        public SensorDataModel Create(SensorDataModel data)
        {
            data.TimeStamp = DateTime.Now;
            data.Sensor = _sensorRepository.Get(data.SensorId);
            return _sensorDataRepository.Post(data);
        }

        public SensorDataModel Update(SensorDataModel data)
        {
            data.Sensor = _sensorRepository.Get(data.SensorId);
            return _sensorDataRepository.Put(data);
        }

        public bool Delete(int id)
        {
            return _sensorDataRepository.Delete(id);
        }

        public List<SensorDataModel> GetAll()
        {
            return _sensorDataRepository.GetAll();
        }

        public SensorDataModel Get(int id)
        {
            return _sensorDataRepository.Get(id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;
using Models;
using Repositories;
using System.Linq;

namespace Services
{
    public class LastSensorDataService
    {
        private SensorDataRepository _sensorDataRepository;

        public LastSensorDataService(SensorDataRepository sensorDataRepository)
        {
            _sensorDataRepository = sensorDataRepository;
        }

        public LastSensorData Get(int id, int count)
        {
            var allSensorData = _sensorDataRepository.GetAll();
            var sensorData = new List<SensorDataModel>();
            foreach(SensorDataModel s in allSensorData.Where(x => x.SensorId == id)) // select sensordata for specific sensor
            {
                sensorData.Add(s);
            }

           List<SensorDataModel> orderedSensorData = sensorData.OrderByDescending(x => x.TimeStamp).ToList();// order list
           
            if(count <= orderedSensorData.Count)
            {
                orderedSensorData.RemoveRange(count, orderedSensorData.Count - count); // split list
            }          
            var lastSensorData = new LastSensorData()
            {
                SensorData = orderedSensorData
            };

            return lastSensorData;

        } 
    }
}

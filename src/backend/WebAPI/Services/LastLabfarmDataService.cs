using System;
using System.Collections.Generic;
using System.Text;
using Models;
using ViewModels;
using Repositories;
using System.Linq;

namespace Services
{
    //Bussines logic
    public class LastLabfarmDataService
    {
        private LabFarmRepository _labfarmRepository;
        private SensorDataRepository _sensorDataRepository;
        private SensorRepository _sensorRepository;

        public LastLabfarmDataService(LabFarmRepository labFarmRepository, SensorDataRepository sensorDataRepository, SensorRepository sensorRepository)
        {
            _labfarmRepository = labFarmRepository;
            _sensorDataRepository = sensorDataRepository;
            _sensorRepository = sensorRepository;         
        }

        public LastLabfarmData Get(int id)
        {
            var sensorTypes = new List<String>();
            var latestSensorDataObject = new LastLabfarmData();
            latestSensorDataObject.LatestSensorValues = new List<LatestData>();

            latestSensorDataObject.LabFarm = _labfarmRepository.Get(id); // get labfarm
            sensorTypes.Add(""); // prevent empty sensorType in list

            var sensorDatas = _sensorDataRepository.GetAll();
            foreach (SensorDataModel m in sensorDatas.Where(s => s.Sensor.LabFarmId == id)) // get all sensorTypes
            {
                if(m.Sensor.SensorType != null) // null check
                {
                    if (!sensorTypes.Contains(m.Sensor.SensorType.Name))
                    {
                        sensorTypes.Add(m.Sensor.SensorType.Name);
                    }
                }
            }
            sensorTypes.Remove("");

            var sensors = _sensorRepository.GetAll(); // get all sensors

           // foreach(SensorModel s in sensors.Where(n => n.LabFarmId == id)) // select sensors for specif labfarm
           // {
                for (int i = 0; i < sensorTypes.Count; i++)// check all sensor types
                {
                    var latestSensorData = new SensorDataModel();
                    latestSensorData.TimeStamp = DateTime.Now.AddYears(-99); // get earliest date

                    foreach (SensorDataModel x in sensorDatas.Where(n => n.Sensor.SensorType.Name == sensorTypes[i] && n.Sensor.LabFarmId == id))// get all sensordata's for specific sensorType and labfarm
                    {
                        if (x.TimeStamp != null) // null object reference check
                        {
                            if (DateTime.Compare(x.TimeStamp, latestSensorData.TimeStamp) > 0) // Greater than zer=> t1 is later than t2.
                            {
                                latestSensorData = x;
                            }
                        }
                    }
                    var data = new LatestData(); // todo double initialize??

                    if (latestSensorData.Sensor != null) // null object reference check
                    {
                        data = new LatestData() // create viewmodel object
                        {
                             Value = latestSensorData.SensorValue,
                            TimeStamp = latestSensorData.TimeStamp,
                            SensorType = latestSensorData.Sensor.SensorType
                        };
                    }

                    if (!latestSensorDataObject.LatestSensorValues.Contains(data)) //  check for double
                    {
                        latestSensorDataObject.LatestSensorValues.Add(data);
                    }

                //}
            }

            return latestSensorDataObject;
        }
    }
}

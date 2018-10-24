using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ViewModels
{
    public class LastLabfarmData
    {
        public LabFarmModel LabFarm { get; set; }
        public List<LatestData> LatestSensorValues { get; set; }
    }

    public class LatestData
    {
        public float Value { get; set; }
        public DateTime TimeStamp { get; set; }
        public SensorType SensorType { get; set; }
    }
}

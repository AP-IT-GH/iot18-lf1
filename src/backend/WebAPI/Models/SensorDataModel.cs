using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class SensorDataModel
    {
        public int Id { get; set; }
        public float SensorValue { get; set; }
        public DateTime TimeStamp { get; set; }
        public int SensorId { get; set; }//FK
        public SensorModel Sensor { get; set; }
    }
}

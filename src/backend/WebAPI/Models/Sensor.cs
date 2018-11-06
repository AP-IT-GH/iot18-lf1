using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Models
{
    public class SensorType
    {
        public int Id {get; set;}
        public string Name {get; set;}
        [JsonIgnore]
        public ICollection<Sensor> Sensors {get; set;}
    }
    public class Sensor
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        [ForeignKey("LabFarm")]
        public int LabFarmId { get; set; }
        [JsonIgnore]
        public LabFarm LabFarm {get; set;}

        [ForeignKey("SensorType")]
        public int SensorTypeId { get; set; }
        public SensorType SensorType {get; set;}

        public ICollection<SensorData> SensorValues { get; set; }
    }
    
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    public class SensorType
    {
        public int Id {get; set;}
        public string Name {get; set;}
        [JsonIgnore]
        public ICollection<SensorModel> Sensors {get; set;}
    }
    public class SensorModel
    {
        public int Id { get; set; } 
        public int LabFarmId { get; set; }//FK
        public LabFarmModel LabFarm {get; set;}
        public int SensorTypeId { get; set; }//FK
        public SensorType SensorType {get; set;}
        [JsonIgnore]
        public ICollection<SensorDataModel> SensorValues { get; set; }
    }
    
}

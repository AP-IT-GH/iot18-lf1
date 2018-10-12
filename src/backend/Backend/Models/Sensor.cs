using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    /* public  class SensorType
    {
        public int Id { get; set; }
        public string Name {get; set;}

        [JsonIgnore]
        public ICollection<Camera> Cameras {get; set;}
    }

    public class AciditySensor : SensorType
    {
        public AciditySensor(){this.Name = "AciditySensor";}       
    }
    public class LightSensor : SensorType
    {
        public LightSensor(){this.Name = "LightSensor";}       
    }
    public class HumiditySensor : SensorType
    {
        public HumiditySensor(){this.Name = "HumiditySensor";}       
    }
    public class ConductivitySensor : SensorType
    {
        public ConductivitySensor(){this.Name = "ConductivitySensor";}       
    } */
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
        public LabFarm LabFarm {get; set;}
        public float Value {get; set;}
        public TimeSpan TimeStamp {get; set;}
        public SensorType SensorType {get; set;}
    }
    
}

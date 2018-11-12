using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models
{
    public class LabFarm
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string AuthId {get; set;}
        public string PlantSpecies { get; set; }
        public float DustLevelHigh {get; set;}
        public float DustLevelLow {get; set;}
        public float LightLevelHigh {get; set;}
        public float LightLevelLow {get; set;}
        public float TemperatureLevelHigh {get; set;}
        public float TemperatureLevelLow {get; set;}
        public float ConductivityLevelHigh {get; set;}
        public float ConductivityLevelLow { get; set;}
        public float MinimumReservoirLevel {get; set;}
        public float MaximumReservoirLevel { get; set; }
        public bool AutoMode { get; set; }

        public ICollection<Plant> Plants { get; set;}
        public ICollection<Sensor> Sensors {get; set;}

    }
}
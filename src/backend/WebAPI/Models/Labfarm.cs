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
        public float OptimalAcidityLevelHigh {get; set;}
        public float OptimalAcidityLevelLow {get; set;}
        public float OptimalHumidityLevelHigh {get; set;}
        public float OptimalHumidityLevelLow {get; set;}
        public float OptimalLightLevelHigh {get; set;}
        public float OptimalLightLevelLow {get; set;}
        public float OptimalConductivityLevelHigh {get; set;}
        public float OptimalConductivityLevelLow {get; set;}
        public float MinimumReservoirLevel {get; set;}
        public bool AutoMode { get; set; }

        public ICollection<Plant> Plants { get; set;}
        public ICollection<Sensor> Sensors {get; set;}

    }
}
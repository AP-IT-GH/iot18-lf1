using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PlantDataSet
    {
        public int Id { get; set; }
        public string PlantSpecies { get; set; }
        public float DustLevelHigh { get; set; }
        public float DustLevelLow { get; set; }
        public float LightLevelHigh { get; set; }
        public float LightLevelLow { get; set; }
        public float TemperatureLevelHigh { get; set; }
        public float TemperatureLevelLow { get; set; }
        public float ConductivityLevelHigh { get; set; }
        public float ConductivityLevelLow { get; set; }
        public float MinimumReservoirLevel { get; set; }
        public float MaximumReservoirLevel { get; set; }
 
    }
}

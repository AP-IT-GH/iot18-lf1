using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Configuration
    {
        public int Id { get; set; }
        public bool Valve { get; set; }
        public int Pump { get; set; }

        [ForeignKey("Labfarm")]
        public int LabfarmId { get; set; }
        [JsonIgnore]
        public LabFarm Labfarm { get; set; }
    }
}

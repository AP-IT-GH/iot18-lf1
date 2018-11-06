using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class SensorData
    {
        public int Id { get; set; }
        public float SensorValue { get; set; }
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Sensor")]
        public int SensorId { get; set; }
        [JsonIgnore]
        public Sensor Sensor { get; set; }
    }
}

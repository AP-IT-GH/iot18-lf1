using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Plant")] // optional
        public int? PlantId { get; set; } //nullable integer
        [JsonIgnore]
        public Plant Plant { get; set; }

    }
}

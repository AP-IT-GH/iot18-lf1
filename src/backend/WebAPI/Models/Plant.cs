using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("LabFarm")]
        public int LabfarmId { get; set; }
        [JsonIgnore]
        public LabFarm Labfarm { get; set; }

        public int Column {get; set;}
        public int Row {get; set;}
 
        public ICollection<Picture> Pictures { get; set; }

    }
}
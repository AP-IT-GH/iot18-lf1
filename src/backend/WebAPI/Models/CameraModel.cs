using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Models
{
    public class CameraModel
    {
        public int Id { get; set; } 
        public LabFarmModel Labfarm { get; set; }
        public int Column {get; set;}
        public int Row {get; set;}
        [JsonIgnore]
        public ICollection<CameraModel> Cameras { get; set; }

    }
}
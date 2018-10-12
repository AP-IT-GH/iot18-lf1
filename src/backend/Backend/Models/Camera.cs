using System;

namespace Models
{
    public class Camera
    {
        public long Id { get; set; } 
        public LabFarm Labfarm { get; set; }
        public int Column {get; set;}
        public int Row {get; set;}
        public string ImagePath {get; set;}
        public TimeSpan TimeStamp {get; set;}

    }
}
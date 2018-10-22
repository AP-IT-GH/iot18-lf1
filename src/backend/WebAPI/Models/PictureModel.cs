using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public CameraModel Camera { get; set; }

    }
}

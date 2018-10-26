using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public int CameraId { get; set; }//FK
        public CameraModel Camera { get; set; }

    }
}

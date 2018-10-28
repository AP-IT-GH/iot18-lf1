using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models;

namespace ViewModels
{
    public class LastSensorValues
    {
        public string Name { get; set; }
        public List<SensorData> Data { get; set; }
    }

}

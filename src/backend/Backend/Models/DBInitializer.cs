using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Models
{
    public class DBInitializer
    {
        public static void Initialize(CollectionContext context)
        {
            //create db if not yet exists
            context.Database.EnsureCreated();

            if(!context.Cameras.Any() && !context.LabFarms.Any() && !context.Sensors.Any() && !context.SensorTypes.Any()) //check if database is empty
            {
                var Labfarm1 = new LabFarm() // add item
                {
                    PlantSpecies = "pisbloem"
                };
                
                var Camera1 = new Camera() // add item
                {
                    Labfarm = Labfarm1,
                    Column = 2,
                    Row = 3
                };

                var SensorType1 = new SensorType()
                {
                    Name = "LightSensor",
                };
                var Sensor1 = new Sensor()// add item
                {
                    LabFarm = Labfarm1,
                    SensorType = SensorType1
                };


                context.LabFarms.Add(Labfarm1);
                context.Sensors.Add(Sensor1);
                context.Cameras.Add(Camera1);
                context.SensorTypes.Add(SensorType1);
                //save all the changes to the DB
                context.SaveChanges();
                
            }
        }
    }
}
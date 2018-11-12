using System.IO;
using System.Linq;
using Models;
using System.Drawing;

namespace Repositories
{
    public class DBInitializer
    {

        public static void Initialize(CollectionContext context)
        {
            //create db if not yet exists
            context.Database.EnsureCreated();

           if(!context.SensorTypes.Any()) //check if database is empty
            {

                //initialize 4 base sensorTypes
                var SensorType1 = new SensorType()
                {
                    Name = "DustSensor",
                };
                context.SensorTypes.Add(SensorType1);

                var SensorType2 = new SensorType()
                {
                    Name = "LightSensor",
                };
                context.SensorTypes.Add(SensorType2);
                var SensorType3 = new SensorType()
                {
                    Name = "ConductivitySensor",
                };
                context.SensorTypes.Add(SensorType3);
                var SensorType4 = new SensorType()
                {
                    Name = "TemperatureSensor",
                };
                context.SensorTypes.Add(SensorType4);
                var SensorType5 = new SensorType()
                {
                    Name = "WaterSensor",
                };
                context.SensorTypes.Add(SensorType5);

                //save all the changes to the DB
                context.SaveChanges();
                
            } 
        }
        
    }
}
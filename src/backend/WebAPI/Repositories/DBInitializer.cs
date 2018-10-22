using System.Linq;
using Models;

namespace Repositories
{
    public class DBInitializer
    {
        public static void Initialize(CollectionContext context)
        {
            //create db if not yet exists
            context.Database.EnsureCreated();

            if(!context.Cameras.Any() && !context.LabFarms.Any() && !context.Sensors.Any() && !context.SensorTypes.Any()) //check if database is empty
            {
                var Labfarm1 = new LabFarmModel() // add item
                {
                    PlantSpecies = "pisbloem",
                    AuthId = "admin",            
                };
                
                var Camera1 = new CameraModel() // add item
                {
                    Labfarm = Labfarm1,
                    Column = 2,
                    Row = 3
                };

                var Picture1 = new PictureModel()
                {
                    ImagePath = "url/test/1",
                    Camera = Camera1
                };
                var Picture2 = new PictureModel()
                {
                    ImagePath = "url/test/2",
                    Camera = Camera1
                };

                var SensorType1 = new SensorType()
                {
                    Name = "LightSensor",
                };
                var SensorType2 = new SensorType()
                {
                    Name = "HumiditySensor",
                };
                var Sensor1 = new SensorModel()// add item
                {
                    LabFarm = Labfarm1,
                    SensorType = SensorType1
                };
                var Sensor2 = new SensorModel()// add item
                {
                    LabFarm = Labfarm1,
                    SensorType = SensorType2
                };
                var SensorValue1 = new SensorDataModel()
                {
                    SensorValue = 123,
                    Sensor = Sensor1
                };
                var SensorValue2 = new SensorDataModel()
                {
                    SensorValue = 123,
                    Sensor = Sensor1
                };
                var SensorValue3 = new SensorDataModel()
                {
                    SensorValue = 123,
                    Sensor = Sensor2
                };


                context.LabFarms.Add(Labfarm1);
                context.Cameras.Add(Camera1);
                context.Pictures.Add(Picture1);
                context.Pictures.Add(Picture2);               
                context.SensorTypes.Add(SensorType1);
                context.SensorTypes.Add(SensorType2);
                context.Sensors.Add(Sensor1);
                context.Sensors.Add(Sensor2);
                context.SensorValues.Add(SensorValue1);
                context.SensorValues.Add(SensorValue2);
                context.SensorValues.Add(SensorValue3);
                //save all the changes to the DB
                context.SaveChanges();
                
            }
        }
    }
}
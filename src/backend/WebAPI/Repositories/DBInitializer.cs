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
                context.LabFarms.Add(Labfarm1);

                var Camera1 = new CameraModel() // add item
                {
                    Labfarm = Labfarm1,
                    Column = 2,
                    Row = 3
                };              
                context.Cameras.Add(Camera1);

                var Picture1 = new PictureModel()
                 {
                      ImagePath = "url/test/1",
                      CameraId = Camera1.Id
                 };
                context.Pictures.Add(Picture1);

                var Picture2 = new PictureModel()
                {
                      ImagePath = "url/test/2",
                      CameraId = Camera1.Id
                };
                context.Pictures.Add(Picture2);

                var SensorType1 = new SensorType()
                 {
                      Name = "LightSensor",
                 };
                context.SensorTypes.Add(SensorType1);

                var SensorType2 = new SensorType()
                  {
                      Name = "HumiditySensor",
                  };
                context.SensorTypes.Add(SensorType2);

                var Sensor1 = new SensorModel()// add item
                  {
                      LabFarm = Labfarm1,
                      SensorTypeId = SensorType1.Id
                  };
                context.Sensors.Add(Sensor1);

                var Sensor2 = new SensorModel()// add item
                  {
                      LabFarm = Labfarm1,
                      SensorTypeId = SensorType2.Id
                  };
                context.Sensors.Add(Sensor2);

                var SensorValue1 = new SensorDataModel()
                  {
                      SensorValue = 123,
                      SensorId = Sensor1.Id
                  };
                context.SensorValues.Add(SensorValue1);

                var SensorValue2 = new SensorDataModel()
                  {
                      SensorValue = 123,
                      SensorId = Sensor1.Id
                  };
                context.SensorValues.Add(SensorValue2);

                var SensorValue3 = new SensorDataModel()
                  {
                      SensorValue = 123,
                      SensorId = Sensor2.Id
                  };
                context.SensorValues.Add(SensorValue3); 
                

                //save all the changes to the DB
                context.SaveChanges();
                
            } 
        }
    }
}
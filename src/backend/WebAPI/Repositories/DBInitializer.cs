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

           if(!context.LabFarms.Any()) //check if database is empty
            {

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
                    Name = "LightSensor",
                };
                context.SensorTypes.Add(SensorType3);
                var SensorType4 = new SensorType()
                {
                    Name = "LightSensor",
                };
                context.SensorTypes.Add(SensorType4);

                var Labfarm1 = new LabFarm() // add item
                {
                    Name = "Test Labfarm",
                    PlantSpecies = "Test Bloem",
                    AuthId = "Test admin",    
                    DustLevelHigh = 28,
                    DusLevelLow = 12,
                    ConductivityLevelHigh = 123,
                    ConductivityLevelLow = 45,
                    TemperatureLevelHigh = 100,
                    TemperatureLevelLow = 0,
                    LightLevelHigh = 3000,
                    LightLevelLow = 2000,
                    MaximumReservoirLevel = 20,
                    MinimumReservoirLevel = -20,

                };
                context.LabFarms.Add(Labfarm1); 

                var Plant1 = new Plant() // add item
                {
                    Name = "Test plant1",
                    Labfarm = Labfarm1,
                    Column = 2,
                    Row = 3
                };              
                context.Plants.Add(Plant1);

                var Picture1 = new Picture()
                 {
                     Content = "Base64 datata",
                     Plant = Plant1
                };
                context.Pictures.Add(Picture1);

                var Picture2 = new Picture()
                {
                    Content = "Base64 datata",
                    Plant = Plant1
                };
                context.Pictures.Add(Picture2);
               

                var Sensor1 = new Sensor()
                {
                    Name = "Test sensor1",
                    LabFarm = Labfarm1,
                    SensorType = SensorType1
                };
                context.Sensors.Add(Sensor1);


                var Sensor2 = new Sensor()
                {
                    Name = "Test sensor2",
                    LabFarm = Labfarm1,
                    SensorType = SensorType2
                };
                context.Sensors.Add(Sensor2);

                   var SensorValue1 = new SensorData()
                     {
                         SensorValue = 124683,
                         Sensor = Sensor1
                     };
                   context.SensorValues.Add(SensorValue1);

                   var SensorValue2 = new SensorData()
                     {
                         SensorValue = 996213653,
                         Sensor = Sensor1
                     };
                   context.SensorValues.Add(SensorValue2);

                   var SensorValue3 = new SensorData()
                     {
                         SensorValue = 12963883,
                         Sensor = Sensor2
                     };
                   context.SensorValues.Add(SensorValue3); 


                //save all the changes to the DB
                context.SaveChanges();
                
            } 
        }
        
    }
}
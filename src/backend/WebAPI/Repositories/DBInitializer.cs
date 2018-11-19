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

           if(!context.SensorTypes.Any()) //check if database.sensortypes is empty
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

            if (!context.DataSets.Any())// check if database.datasets is empty
            {
                var set1 = new PlantDataSet()
                {
                    PlantSpecies = "Dille",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set2 = new PlantDataSet()
                {
                    PlantSpecies = "Koriander",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set3 = new PlantDataSet()
                {
                    PlantSpecies = "Lavendel",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set4 = new PlantDataSet()
                {
                    PlantSpecies = "Basilicum",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set5 = new PlantDataSet()
                {
                    PlantSpecies = "Stevia",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set6 = new PlantDataSet()
                {
                    PlantSpecies = "Tijm",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set7 = new PlantDataSet()
                {
                    PlantSpecies = "Tuinkers",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set8 = new PlantDataSet()
                {
                    PlantSpecies = "Bieslook",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
                var set9 = new PlantDataSet()
                {
                    PlantSpecies = "Munt",
                    DustLevelHigh = 0,
                    DustLevelLow = 0,
                    LightLevelHigh = 0,
                    LightLevelLow = 0,
                    TemperatureLevelHigh = 0,
                    TemperatureLevelLow = 0,
                    ConductivityLevelHigh = 0,
                    ConductivityLevelLow = 0,
                    MinimumReservoirLevel = 0,
                    MaximumReservoirLevel = 0,
                };
            }
        }
        
    }
}
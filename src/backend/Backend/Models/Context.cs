using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class CollectionContext : DbContext
    {
        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {

        }

        //add database tables
        public DbSet<Camera> Cameras {get; set;}
        public DbSet<LabFarm> LabFarms {get; set;}
        public DbSet<Sensor> Sensors {get; set;}
        public DbSet<SensorType> SensorTypes {get; set;}

    }
}
//main class that coordinates Entity Framework functionality for a given data model.
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class CollectionContext : DbContext
    {
        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {

        }

        //add database tables
        public DbSet<CameraModel> Cameras {get; set;}
        public DbSet<LabFarmModel> LabFarms {get; set;}
        public DbSet<SensorModel> Sensors {get; set;}
        public DbSet<SensorType> SensorTypes {get; set;}
        public DbSet<SensorDataModel> SensorValues { get; set; }
        public DbSet<PictureModel> Pictures { get; set; }

    }
}
//main class that coordinates Entity Framework functionality for a given data model.
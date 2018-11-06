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
       
        public DbSet<LabFarm> LabFarms {get; set;}
        public DbSet<Sensor> Sensors {get; set;}
        public DbSet<SensorType> SensorTypes {get; set;}
        public DbSet<SensorData> SensorValues { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure one-to-many relationship
            modelBuilder.Entity<Picture>()
                .HasOne(s => s.Plant)
                .WithMany(s => s.Pictures)
                .HasForeignKey(s => s.PlantId);

            // configure one-to-many relationship
            modelBuilder.Entity<Plant>()
                .HasOne(s => s.Labfarm)
                .WithMany(s => s.Plants)
                .HasForeignKey(s => s.LabfarmId);

            // configure one-to-many relationship
            modelBuilder.Entity<SensorData>()
                .HasOne(s => s.Sensor)
                .WithMany(s => s.SensorValues)
                .HasForeignKey(s => s.SensorId);

            // configure one-to-many relationship
            modelBuilder.Entity<Sensor>()
                 .HasOne(s => s.LabFarm)
                 .WithMany(s => s.Sensors)
                .HasForeignKey(s => s.LabFarmId);

            // configure one-to-many relationship
            modelBuilder.Entity<Sensor>()
                 .HasOne(s => s.SensorType)
                 .WithMany(s => s.Sensors)
                .HasForeignKey(s => s.SensorTypeId);

        }



    }
}
//main class that coordinates Entity Framework functionality for a given data model.
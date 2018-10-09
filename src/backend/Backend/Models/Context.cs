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
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoItem2> TodoItems2 { get; set; }

    }
}
//main class that coordinates Entity Framework functionality for a given data model.
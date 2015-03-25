using testLogin.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace testLogin.DAL
{
    public class planContext :DbContext
    {
        public planContext() : base("planContext") { 
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Floorplan> Floorplans { get; set; }
        public DbSet<tableObject> tableObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("bourguestMob");
            base.OnModelCreating(modelBuilder);
        }
    }
}
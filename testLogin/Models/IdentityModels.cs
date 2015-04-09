using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace testLogin.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Floorplan> Floorplan { get; set; }
        public DbSet<tableObject> tableObject { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<tableObjectBookings> tableObjectBookings { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<UsersTable> UsersTable { get; set; }
        public DbSet<UserReviews> UserReviews { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>().ToTable("WebUsers");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("WebUserRoles");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("WebUserLogins");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("WebUserClaims");
            //modelBuilder.Entity<IdentityRole>().ToTable("WebRoles");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("bourguestMob");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
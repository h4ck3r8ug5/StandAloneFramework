using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MediaCentre
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MediaCentreEntities")
        {
            
        }

        public DbSet<Movie> Students { get; set; }
        public DbSet<Year> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
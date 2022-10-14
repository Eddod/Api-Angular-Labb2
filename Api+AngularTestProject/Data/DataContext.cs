using Microsoft.EntityFrameworkCore;

namespace Api_AngularTestProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Department> DepartmentTbl { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);






        }
    }
}

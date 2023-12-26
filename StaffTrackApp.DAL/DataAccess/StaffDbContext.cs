using Microsoft.EntityFrameworkCore;
using StaffTrackApp.Common.Entities;
using StaffTrackApp.Common.Entities.Configurations;

namespace StaffTrackApp.DAL.DataAccess
{
    public class StaffDbContext : DbContext
    {
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }

        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PositionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfiguration());
        }
    }

}

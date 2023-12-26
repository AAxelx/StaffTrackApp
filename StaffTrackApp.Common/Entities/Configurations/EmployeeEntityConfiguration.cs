using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StaffTrackApp.Common.Entities.Configurations
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentId");
            builder.Property(e => e.PositionId).HasColumnName("PositionId");
            builder.Property(e => e.FullName).HasColumnName("FullName").HasMaxLength(50).IsRequired();
            builder.Property(e => e.Address).HasColumnName("Address").HasMaxLength(100).IsRequired();
            builder.Property(e => e.Phone).HasColumnName("Phone").HasMaxLength(20).IsRequired();
            builder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth").IsRequired();
            builder.Property(e => e.EmploymentDate).HasColumnName("EmploymentDate").IsRequired();
            builder.Property(e => e.Salary).HasColumnName("Salary").HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Position)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

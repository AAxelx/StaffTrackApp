using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StaffTrackApp.Common.Entities.Configurations
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.DepartmentName).HasColumnName("DepartmentName").HasMaxLength(50).IsRequired();
        }
    }
}

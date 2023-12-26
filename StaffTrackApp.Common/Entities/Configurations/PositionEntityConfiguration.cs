using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace StaffTrackApp.Common.Entities.Configurations
{
    public class PositionEntityConfiguration : IEntityTypeConfiguration<PositionEntity>
    {
        public void Configure(EntityTypeBuilder<PositionEntity> builder)
        {
            builder.ToTable("Positions");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.PositionName).HasColumnName("PositionName").HasMaxLength(50).IsRequired();
        }
    }
}

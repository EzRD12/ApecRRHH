using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class PreparationConfiguration : IEntityTypeConfiguration<Preparation>
    {
        void IEntityTypeConfiguration<Preparation>.Configure(EntityTypeBuilder<Preparation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(700);
            builder.Property(p => p.Institution)
                .IsRequired()
                .HasMaxLength(700);
            builder.Property(p => p.AcademicLevel)
                .IsRequired();
            builder.Property(p => p.DateFrom)
                .IsRequired();
            builder.Property(p => p.DateUp)
                .IsRequired();
            builder.Property(p => p.UserId)
                .IsRequired();
        }
    }
}

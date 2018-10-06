using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
    {
        void IEntityTypeConfiguration<WorkExperience>.Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.PositionHeld)
                .IsRequired()
                .HasMaxLength(700);
            builder.Property(work => work.DateFrom).IsRequired();
            builder.Property(work => work.DateUp).IsRequired();
            builder.Property(work => work.Salary).IsRequired();
            builder.Property(work => work.UserId).IsRequired();
            builder.Property(work => work.CurrencyType).IsRequired();

            builder.Ignore(user => user.YearExperiences);
        }
    }
}

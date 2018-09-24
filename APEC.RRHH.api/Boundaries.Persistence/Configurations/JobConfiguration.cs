using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        void IEntityTypeConfiguration<Job>.Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.DepartamentId)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(job => job.RiskLevel).IsRequired();
            builder.Property(job => job.MaximumSalary).IsRequired();
            builder.Property(job => job.MinimumSalary).IsRequired();
            builder.Property(job => job.MinimumYearsExperienceLaboral).IsRequired();
            builder.Property(job => job.CurrencyType).IsRequired();
            builder.Property(job => job.MaximumSalary).IsRequired();
            builder.HasMany(job => job.JobCompetences);
            builder.HasMany(job => job.JobLanguages);
            builder.HasMany(job => job.Employees);
        }
    }
}

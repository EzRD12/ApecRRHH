using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class CandidateEmployeeAspiratedJobsConfiguration : IEntityTypeConfiguration<CandidateEmployeeAspiratedJob>
    {
        public void Configure(EntityTypeBuilder<CandidateEmployeeAspiratedJob> builder)
        {
            builder.HasKey(p => new { p.CandidateEmployeeId, p.JobId });
            builder.Property(p => p.SalaryToAspire)
                .IsRequired();
            builder.Property(job => job.UserId).IsRequired(false);
        }
    }
}

using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class CandidateInterviewConfiguration : IEntityTypeConfiguration<CandidateInterview>
    {
        public void Configure(EntityTypeBuilder<CandidateInterview> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.InterviewDate).IsRequired();
            builder.Property(p => p.CandidateEmployeeId).IsRequired();
            builder.Property(p => p.JobId).IsRequired();
            builder.Property(p => p.EmployeeId).IsRequired();
        }
    }
}

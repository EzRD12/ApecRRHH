using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class CandidateInterviewConfiguration : IEntityTypeConfiguration<CandidateInterview>
    {
        public void Configure(EntityTypeBuilder<CandidateInterview> builder)
        {
            builder.HasKey(p => new { p.CandidateEmployeeId, p.JobId});
            builder.Property(p => p.InterviewDate).IsRequired();

        }
    }
}

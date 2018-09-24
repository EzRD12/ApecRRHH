using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class CandidateEmployeeConfiguration : IEntityTypeConfiguration<CandidateEmployee>
    {
        void IEntityTypeConfiguration<CandidateEmployee>.Configure(EntityTypeBuilder<CandidateEmployee> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.JobToAspire)
                .IsRequired();
            builder.Property(p => p.SalaryToAspire)
                .IsRequired();
            builder.Property(job => job.UserId).IsRequired();
            builder.Property(job => job.UserIdWhoRecommendedIt).IsRequired(false);
        }
    }
}

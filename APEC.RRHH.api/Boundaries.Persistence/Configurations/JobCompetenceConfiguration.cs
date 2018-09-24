using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class JobCompetenceConfiguration : IEntityTypeConfiguration<JobCompetence>
    {
        void IEntityTypeConfiguration<JobCompetence>.Configure(EntityTypeBuilder<JobCompetence> builder) 
            => builder.HasKey(p => new { p.JobId, p.CompetenceId });
    }
}

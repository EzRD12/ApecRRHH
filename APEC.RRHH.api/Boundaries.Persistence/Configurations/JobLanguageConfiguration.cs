using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class JobLanguageConfiguration : IEntityTypeConfiguration<JobLanguage>
    {
        void IEntityTypeConfiguration<JobLanguage>.Configure(EntityTypeBuilder<JobLanguage> builder)
            => builder.HasKey(p => new { p.JobId, p.LanguageId });
    }
}

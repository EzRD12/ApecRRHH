using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
    {
        void IEntityTypeConfiguration<UserLanguage>.Configure(EntityTypeBuilder<UserLanguage> builder)
            => builder.HasKey(p => new { p.UserId, p.LanguageId });
    }
}

using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class UserCompetenceConfiguration : IEntityTypeConfiguration<UserCompetence>
    {
        void IEntityTypeConfiguration<UserCompetence>.Configure(EntityTypeBuilder<UserCompetence> builder)
            => builder.HasKey(p => new { p.UserId, p.CompetenceId });
    }
}

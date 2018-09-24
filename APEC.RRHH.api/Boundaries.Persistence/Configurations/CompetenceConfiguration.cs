using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class CompetenceConfiguration : IEntityTypeConfiguration<Competence>
    {
        void IEntityTypeConfiguration<Competence>.Configure(EntityTypeBuilder<Competence> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.Description)
                .IsRequired();
            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}

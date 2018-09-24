using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        void IEntityTypeConfiguration<Departament>.Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.Status)
                .IsRequired();
            builder.HasMany(departement => departement.Jobs);
        }
    }
}

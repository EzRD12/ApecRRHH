using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(700);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(700);
            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(900);
            builder.HasIndex(p => p.Email)
                .IsUnique();
            builder.HasMany(user => user.Preparations);
            builder.HasMany(user => user.WorkExperiences);
            builder.Property(p => p.Birthdate)
                .IsRequired();
            builder.Property(p => p.CurrentRole)
                .IsRequired();
            builder.Property(p => p.Identification)
                .IsRequired();
            builder.Property(p => p.Status)
                .IsRequired();
            builder.HasMany(user => user.UserCompetences);
            builder.HasMany(user => user.UserLanguages);

            builder.Ignore(user => user.FullName);
        }
    }
}

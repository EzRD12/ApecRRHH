using Boundaries.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.Models;

namespace Boundaries.Persistence.Context
{
    public sealed class ApecRrhhContext : DbContext
    {
        public ApecRrhhContext(DbContextOptions options): base(options) { }

        internal DbSet<Employee> Employees { get; set; }

        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            foreach (var pb in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string))
                .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name)))
            {
                pb.HasColumnType("varchar(400)");
            }

            ApplyConfigurations(modelBuilder);
        }

        private static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new JobCompetenceConfiguration());
            modelBuilder.ApplyConfiguration(new JobLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new PreparationConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateEmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartamentConfiguration());
            modelBuilder.ApplyConfiguration(new CompetenceConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new UserCompetenceConfiguration());
            modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new WorkExperienceConfiguration());
        }
    }
}

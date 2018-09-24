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
        }
    }
}

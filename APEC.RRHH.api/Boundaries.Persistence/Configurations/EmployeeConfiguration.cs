using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        void IEntityTypeConfiguration<Employee>.Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()");
            builder.Property(p => p.AdmissionDate)
                .IsRequired();
            builder.Property(p => p.MonthlySalary)
                .IsRequired();
            builder.Property(employee => employee.UserId).IsRequired();
            builder.Property(employee => employee.JobId).IsRequired();
        }
    }
}
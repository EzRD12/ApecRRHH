using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Boundaries.Persistence.Context
{
    public class DefaultDbContextFactory : IDesignTimeDbContextFactory<ApecRrhhContext>
    {
        private readonly IConfigurationRoot _config;

        public DefaultDbContextFactory()
        {
            var basePath = AppContext.BaseDirectory;
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        public ApecRrhhContext CreateDbContext(string[] args)
            => Create(_config.GetConnectionString("ApecRRHHDatabase"));

        public ApecRrhhContext CreateDbContext(string connectionString)
            => Create(connectionString);

        ApecRrhhContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)} is null or empty.", nameof(connectionString));
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApecRrhhContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new ApecRrhhContext(optionsBuilder.Options);
        }
    }
}

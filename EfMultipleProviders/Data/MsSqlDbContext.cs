using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfMultipleProviders.Data
{
    public class MsSqlDbContext : WeatherDbContext
    {
        public MsSqlDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var namespaces = new[] { "EfMultipleProviders.Data.Configurations", "EfMultipleProviders.Data.Configurations.MsSql" };
            ApplyConfiguration(modelBuilder, namespaces);
        }
    }
}
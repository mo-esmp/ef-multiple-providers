using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfMultipleProviders.Data
{
    public class PostgresDbContext : MsSqlDbContext
    {
        public PostgresDbContext(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var namespaces = new[] { "EfMultipleProviders.Data.Configurations", "EfMultipleProviders.Data.Configurations.PostgreSql" };
            ApplyConfiguration(modelBuilder, namespaces);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfMultipleProviders.Data
{
    public class CosmosDbContext : WeatherDbContext
    {
        public CosmosDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseCosmos(Configuration.GetConnectionString("CosmosConnection"), "AccountKey");
        }
    }
}
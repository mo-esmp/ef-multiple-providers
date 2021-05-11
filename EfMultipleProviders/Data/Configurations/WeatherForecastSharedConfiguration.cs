using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfMultipleProviders.Data.Configurations
{
    internal class WeatherForecastSharedConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.Ignore(wf => wf.TemperatureF);
        }
    }
}
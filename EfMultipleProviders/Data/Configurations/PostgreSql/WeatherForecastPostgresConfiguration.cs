using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfMultipleProviders.Data.Configurations.PostgreSql
{
    internal class WeatherForecastPostgresConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.Property(wf => wf.TemperatureC).HasColumnType("samllint");
            builder.Property(wf => wf.Date).HasColumnType("timestamp(3)");
            builder.Property(wf => wf.Summary).HasColumnType("varchar(512)").IsRequired(false);
        }
    }
}
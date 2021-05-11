using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfMultipleProviders.Data.Configurations.MsSql
{
    internal class WeatherForecastMsSqlConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.Property(wf => wf.TemperatureC).HasColumnType("tinyint");
            builder.Property(wf => wf.Date).HasColumnType("datetime");
            builder.Property(wf => wf.Summary).HasColumnType("nvarchar(512)").IsRequired(false);
        }
    }
}
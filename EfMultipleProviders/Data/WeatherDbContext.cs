using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EfMultipleProviders.Data;

public abstract class WeatherDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    protected WeatherDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    protected void ApplyConfiguration(ModelBuilder modelBuilder, string[] namespaces)
    {
        var methodInfo = (typeof(ModelBuilder).GetMethods()).Single((e =>
            e.Name == "ApplyConfiguration" &&
            e.ContainsGenericParameters &&
            e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() ==
            typeof(IEntityTypeConfiguration<>)));

        foreach (var configType in typeof(WeatherDbContext)
                     .GetTypeInfo().Assembly
                     .GetTypes()
                     .Where(t => t.Namespace != null &&
                                 namespaces.Any(n => n == t.Namespace) &&
                                 t.GetInterfaces().Any(i => i.IsGenericType &&
                                                            i.GetGenericTypeDefinition() ==
                                                            typeof(IEntityTypeConfiguration<>)
                                 )
                     )
                )
        {
            var type = configType.GetInterfaces().First();
            methodInfo.MakeGenericMethod(type.GenericTypeArguments[0]).Invoke(modelBuilder, new[]
            {
                Activator.CreateInstance(configType)
            });
        }
    }
}
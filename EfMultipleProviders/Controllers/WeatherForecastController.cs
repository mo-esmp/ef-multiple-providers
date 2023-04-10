using EfMultipleProviders.Data;
using Microsoft.AspNetCore.Mvc;

namespace EfMultipleProviders.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get([FromServices] WeatherDbContext context)
    {
        return context.WeatherForecasts.ToList();
    }
}
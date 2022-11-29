using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScaleArch.AadWebApi.Extensions;

namespace ScaleArch.AadWebApi.Controllers;


[ApiController]
[Route("api/[controller]/")]
public class WeatherForecastController : BaseController
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [Authorize(Policies.AFIR)]
    [HttpGet("GetForecastAfir")]
    public async Task<IEnumerable<WeatherForecast>> GetAsyncForAFIR()
    {
        _logger.LogInformation($"UserId {GetUserId()}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [Authorize(Policies.Producer)]
    [HttpGet("GetForecastProducer")]
    public async Task<IEnumerable<WeatherForecast>> GetAsyncForProducer()
    {
        _logger.LogInformation($"UserId {GetUserId()}");
        return Enumerable.Range(1, 2).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SensorClient.Options;
using SensorEmulator;

namespace SensorClient.Controllers;

[Route("events")]
public class SubscriptionController : Controller
{
    private readonly IOptions<ClientConfig> _options;
    private readonly IServiceProvider _provider;

    public SubscriptionController(IOptions<ClientConfig> options, IServiceProvider provider)
    {
        _options = options;
        _provider = provider;
    }
    
    [HttpGet("/subscribe/{sensorType}")]
    public async Task SubscribeToSensorsAsync(SensorType sensorType)
    {
        
    }
}
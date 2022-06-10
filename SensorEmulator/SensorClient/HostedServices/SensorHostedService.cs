using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SensorClient.Models;
using SensorClient.Options;
using SensorType = SensorEmulator.SensorType;

namespace SensorClient.HostedServices;

public class SensorHostedService : BackgroundService
{
    private readonly IOptions<ClientConfig> _options;
    private readonly IEventStorage _eventStorage;
    private readonly IServiceProvider _provider;
    private readonly ILogger<SensorHostedService> _logger;
    
    public static SensorType s_SensorType = SensorType.Both;

    public SensorHostedService(IOptions<ClientConfig> options, IEventStorage eventStorage, IServiceProvider provider, ILogger<SensorHostedService> logger)
    {
        _options = options;
        _eventStorage = eventStorage;
        _provider = provider;
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _provider.CreateAsyncScope();
        var client = scope.ServiceProvider.GetRequiredService<SensorEmulator.EventGenerator.EventGeneratorClient>();
        using var eventResponseStream = client.EventStream(new Empty(), cancellationToken: stoppingToken);
        while (await eventResponseStream.ResponseStream.MoveNext(stoppingToken))
        {
            var e = eventResponseStream.ResponseStream.Current;
            _eventStorage.AddEvent(new SensorEvent
            {
                Id = e.Id,
                Temperature = e.Temperature,
                Humidity = e.Humidity,
                CarbonDioxide = e.CarbonDioxide,
                SensorType = e.SensorType switch
                {
                    SensorType.Room => Models.SensorType.Room,
                    SensorType.Street => Models.SensorType.Street,
                    _ => throw new ArgumentOutOfRangeException()
                },
                UpdateTime = DateTime.Now
            });
            
            _logger.LogInformation($"id: {e.Id} Type: {e.SensorType} Time: {DateTime.Now}");
        }
    }
}
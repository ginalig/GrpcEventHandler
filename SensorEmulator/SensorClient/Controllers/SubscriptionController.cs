using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SensorClient.Models;
using SensorClient.Options;
using SensorEmulator;
using SensorType = SensorEmulator.SensorType;

namespace SensorClient.Controllers;

[Route("events")]
public class SubscriptionController : Controller
{
    private readonly IEventStorage _eventStorage;
    private readonly IOptions<ClientConfig> _options;
    private readonly IServiceProvider _provider;
    private readonly ILogger<SubscriptionController> _logger;
    private GrpcChannel _channel;
    private EventGenerator.EventGeneratorClient _client;
    private AsyncDuplexStreamingCall<TypeRequest, EventResponse> _call;
    private static bool _isStreaming = true;


    public SubscriptionController(IEventStorage eventStorage, IOptions<ClientConfig> options, IServiceProvider provider, ILogger<SubscriptionController> logger)
    {
        _eventStorage = eventStorage;
        _options = options;
        _provider = provider;
        _logger = logger;
        
        _channel = GrpcChannel.ForAddress("http://localhost:7290");
        _client = new EventGenerator.EventGeneratorClient(_channel);
        _call = _client.EventStreamDuplex();

    }
    
    [HttpGet("subscribe/{sensorType}")]
    public async Task SubscribeToSensorsAsync(SensorType sensorType)
    {
        
        var readTask = Task.Run(async () =>
        {
            await foreach (var response in _call.ResponseStream.ReadAllAsync())
            {
                // Обработка ответа сервера.
                _logger.LogInformation(response.ToString());
                _eventStorage.AddEvent(new SensorEvent
                {
                    Id = response.Id,
                    Temperature = response.Temperature,
                    Humidity = response.Humidity,
                    CarbonDioxide = response.CarbonDioxide,
                    SensorType = response.SensorType switch
                    {
                        SensorType.Street => Models.SensorType.Street,
                        SensorType.Room => Models.SensorType.Room
                    },
                    UpdateTime = DateTime.Now
                });
                try
                {
                    _eventStorage.UpdateData(Models.SensorType.Room, _options.Value.AggregationInterval);
                    _eventStorage.UpdateData(Models.SensorType.Street, _options.Value.AggregationInterval);
                }
                catch
                {
                    _logger.LogInformation("*******");
                }
            }
        });

        while (_isStreaming)
        {
            // Отправка запроса на сервер.
            while (true)
            {
                try
                {
                    await _call.RequestStream.WriteAsync(new TypeRequest
                    {
                        SensorType = sensorType switch
                        {
                            SensorType.Both => "Both",
                            SensorType.Room => "Room",
                            SensorType.Street => "Street"
                        }
                    });
                    break;
                }
                catch
                {
                    _logger.LogInformation("Reconnecting...");
                    await Task.Delay(5000);
                    _channel = GrpcChannel.ForAddress("http://localhost:7290");
                    _client = new EventGenerator.EventGeneratorClient(_channel);
                    _call = _client.EventStreamDuplex();
                }
            }
            await Task.Delay(_options.Value.RequestInterval);
        }
        
        _logger.LogInformation("Disconnecting...");
        
        // Закрытие потока.
        await _call.RequestStream.CompleteAsync();
        await readTask;
    }

    [HttpGet("unsubscribe/{sensorType}")]
    public async Task UnsubscribeFromSensorsAsync(SensorType sensorType)
    {
        _isStreaming = false;
    }

    [HttpGet("data/{sensorType}")]
    public ActionResult<SensorsData> GetData(Models.SensorType sensorType)
    {
        _logger.LogInformation(_eventStorage.GetData(sensorType).ToString());
        return Ok(_eventStorage.GetData(sensorType));
    }
    
    [HttpGet("dataWithInterval/{sensorType}")]
    public ActionResult<SensorsData> GetDataWithInterval(Models.SensorType sensorType, [FromQuery] DateTime leftBorder, [FromQuery] DateTime rightBorder)
    {
        var aggregations = _eventStorage.GetAggregatedData(sensorType);
        var query = aggregations.Where(x => x.AggregationTime <= rightBorder && x.AggregationTime >= leftBorder);
        var sensorsDatas = query as SensorsData[] ?? query.ToArray();
        if (sensorsDatas.Length == 0)
            return BadRequest("No data in this interval");
        var result = new SensorsData
        {
            AvgTemperature = sensorsDatas.Sum(x => x.AvgTemperature) / sensorsDatas.Length,
            AvgHumidity = sensorsDatas.Sum(x => x.AvgHumidity) / sensorsDatas.Length,
            MaxCO2 = sensorsDatas.Select(x => x.MaxCO2).Max(),
            MinCO2 = sensorsDatas.Select(x => x.MinCO2).Min(),
            AggregationTime = DateTime.Now
        };
        return Ok(result);
    }
    
    
}
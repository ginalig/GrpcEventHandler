using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Options;
using SensorEmulator.Options;

namespace SensorEmulator.Services;

public class GeneratorService : EventGenerator.EventGeneratorBase
{
    private readonly IOptions<SensorConfig> _options;
    private readonly IEventStorage _eventStorage;
    private readonly ILogger<GeneratorService> _logger;

    private static long _id = 0;

    public GeneratorService(IOptions<SensorConfig> options, IEventStorage eventStorage, ILogger<GeneratorService> logger)
    {
        _options = options;
        _eventStorage = eventStorage;
        _logger = logger;
    }
    
    public override async Task EventStream(Empty request, IServerStreamWriter<EventResponse> responseStream, ServerCallContext context)
    {
        Random random = new();
        try
        {
            while (!context.CancellationToken.IsCancellationRequested)
            {
                var delay = _options.Value.Interval;
                await Task.Delay(delay, context.CancellationToken);
                var roomResult = GenerateRandomResult(random, true);
                var streetResult = GenerateRandomResult(random, false);
                await responseStream.WriteAsync(roomResult, context.CancellationToken);
                await responseStream.WriteAsync(streetResult, context.CancellationToken);
            }
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("A operation was canceled");
        }
    }

    private EventResponse GenerateRandomResult(Random random, bool isRoomSensor)
    {
        _id++;
        IEvent result = new EventResponse
        {
            Id = _id,
            Temperature = GetRandomDouble(random, 22, 24),
            Humidity = GetRandomDouble(random, 65, 70),
            CarbonDioxide = isRoomSensor ? GetRandomDouble(random, 0.03, 0.045) : GetRandomDouble(random, 0.035, 0.04),
            SensorType = isRoomSensor ? SensorType.Room : SensorType.Street
        };
        _eventStorage.AddEvent(_id, result);

        return (EventResponse)result;
    }

    private double GetRandomDouble(Random random, double min, double max) =>
        random.NextDouble() * (max - min) + min;
}
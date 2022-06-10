using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Options;
using SensorEmulator.Options;

namespace SensorEmulator.Services;

public class GeneratorService : EventGenerator.EventGeneratorBase
{
    private readonly IOptions<SensorConfig> _options;
    private readonly IEventStorage _eventStorage;
    private readonly ILogger<GeneratorService> _logger;

    private static long _id = 0;
    private static SensorType _sensorType = SensorType.Both;

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

    public override async Task EventStreamDuplex(
        IAsyncStreamReader<TypeRequest> requestStream,
        IServerStreamWriter<EventResponse> responseStream,
        ServerCallContext context)
    {
        Random random = new();
        var delay = _options.Value.Interval;
        var typeRequest = "Both";
        try
        {
            var readTask = Task.Run(async () =>
            {
                await foreach (var message in requestStream.ReadAllAsync())
                {
                    typeRequest = message.SensorType;
                }
            });


            while (!readTask.IsCompleted && !context.CancellationToken.IsCancellationRequested)
            {
                if (typeRequest == "Room")
                {
                    var roomResult = GenerateRandomResult(random, true);
                    await responseStream.WriteAsync(roomResult, context.CancellationToken);
                }
                else if (typeRequest == "Street")
                {
                    var streetResult = GenerateRandomResult(random, false);
                    await responseStream.WriteAsync(streetResult, context.CancellationToken);
                }
                else
                {
                    var roomResult = GenerateRandomResult(random, true);
                    await responseStream.WriteAsync(roomResult, context.CancellationToken);
                    var streetResult = GenerateRandomResult(random, false);
                    await responseStream.WriteAsync(streetResult, context.CancellationToken);
                }

                await Task.Delay(delay, context.CancellationToken);
            }
            // await RequestTypeAsync(requestStream, context);
            //
            // await EventResponseAsync(responseStream, context, delay, random);
            //
            // await Task.WhenAll(RequestTypeAsync(requestStream, context),
            //     EventResponseAsync(responseStream, context, delay, random));
        }
        catch (ConnectionAbortedException)
        {
            _logger.LogWarning("Connection aborted");
        }
        catch (OperationCanceledException)
        {
            _logger.LogWarning("A operation was canceled");
        }
    }

    private async Task EventResponseAsync(IServerStreamWriter<EventResponse> responseStream, ServerCallContext context, int delay,
        Random random)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await Task.Delay(delay, context.CancellationToken);
            if (_sensorType == SensorType.Room)
            {
                var roomResult = GenerateRandomResult(random, true);
                await responseStream.WriteAsync(roomResult, context.CancellationToken);
            }
            else if (_sensorType == SensorType.Street)
            {
                var streetResult = GenerateRandomResult(random, false);
                await responseStream.WriteAsync(streetResult, context.CancellationToken);
            }
            else
            {
                var roomResult = GenerateRandomResult(random, true);
                await responseStream.WriteAsync(roomResult, context.CancellationToken);
                var streetResult = GenerateRandomResult(random, false);
                await responseStream.WriteAsync(streetResult, context.CancellationToken);
            }
            _logger.LogInformation("sis");
        }
    }

    private async Task RequestTypeAsync(IAsyncStreamReader<TypeRequest> requestStream, ServerCallContext context)
    {
        while (await requestStream.MoveNext() && !context.CancellationToken.IsCancellationRequested)
        {
            _sensorType = requestStream.Current.SensorType switch
            {
                "Room" => SensorType.Room,
                "Street" => SensorType.Street,
                "Both" => SensorType.Both,
                _ => SensorType.Both
            };
            _logger.LogInformation(requestStream.Current.SensorType.ToString());
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

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace SensorEmulator;

public class EventStorage : IEventStorage
{
    private ConcurrentDictionary<long, IEvent> _events = new();
    private IEvent _lastEvent;

    public bool TryGetEvent(long id, [MaybeNullWhen(false)] out IEvent eventResponse) => 
        _events.TryGetValue(id, out eventResponse);

    public void AddEvent(long id, IEvent eventResponse)
    {
        _lastEvent = eventResponse;
        _events.AddOrUpdate(id, _ => eventResponse, (_, _) => eventResponse);
    }

    public IEvent LastEvent => _lastEvent;
    public List<IEvent> LastEvents => 
        _events.OrderBy(x => x.Key).
            Reverse().Take(2).Select(x => x.Value).ToList();
}
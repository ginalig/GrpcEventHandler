using System.Collections.Concurrent;
using System.Collections.Generic;
using SensorClient.Models;

namespace SensorClient;

public class EventStorage : IEventStorage
{
    public ConcurrentDictionary<long, SensorEvent> SensorEvents = new();

    public void AddEvent(SensorEvent sensorEvent)
    {
        SensorEvents.AddOrUpdate(sensorEvent.Id, _ => sensorEvent, (_, _) => sensorEvent);
    }

    public void RemoveEvent(long id)
    {
        SensorEvents.Remove(id, out _);
    }

    public SensorEvent GetById(long id)
    {
        if (SensorEvents.TryGetValue(id, out var sensorEvent))
        {
            return sensorEvent;
        }

        return null;
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using SensorClient.Models;

namespace SensorClient;

public class EventStorage : IEventStorage
{
    public ConcurrentDictionary<long, SensorEvent> SensorEvents = new();
    public List<SensorsData> RoomAggregations = new();
    public List<SensorsData> StreetAggregations = new();
    
    private SensorsData _roomSensorsData;
    private SensorsData _streetSensorsData;

    public SensorsData GetData(SensorType sensorType)
    {
        if (sensorType == SensorType.Room)
            return _roomSensorsData;
        return _streetSensorsData;
    }

    public List<SensorsData> GetAggregatedData(SensorType sensorType)
    {
        if (sensorType == SensorType.Room)
            return RoomAggregations;
        return StreetAggregations;
    }

    public void UpdateData(SensorType sensorType, int interval)
    {
        if (sensorType == SensorType.Room)
        {
            _roomSensorsData = new SensorsData(SensorEvents, sensorType, interval);
            RoomAggregations.Add(_roomSensorsData);
        }

        if (sensorType == SensorType.Street)
        {
            _streetSensorsData = new SensorsData(SensorEvents, sensorType, interval);
            StreetAggregations.Add(_streetSensorsData);
        }
    }

    public ConcurrentDictionary<long, SensorEvent> GetCollection()
    {
        return SensorEvents;
    }

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
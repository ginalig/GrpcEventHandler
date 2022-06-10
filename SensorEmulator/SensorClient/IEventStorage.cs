using System.Collections.Concurrent;
using System.Collections.Generic;
using SensorClient.Models;

namespace SensorClient;

public interface IEventStorage
{
    public SensorsData GetData(SensorType sensorType);
    public List<SensorsData> GetAggregatedData(SensorType sensorType);
    public void UpdateData(SensorType sensorType, int interval);
    public ConcurrentDictionary<long, SensorEvent> GetCollection();
    public void AddEvent(SensorEvent sensorEvent);

    public void RemoveEvent(long id);

    public SensorEvent GetById(long id);
}
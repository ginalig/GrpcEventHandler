using System;
using System.Collections.Concurrent;
using System.Linq;

namespace SensorClient.Models;

public class SensorsData
{
    public double AvgTemperature { get; set; }
    public double AvgHumidity { get; set; }
    public double MinCO2 { get; set; }
    public double MaxCO2 { get; set; }
    public DateTime AggregationTime { get; set; }

    public SensorsData(ConcurrentDictionary<long, SensorEvent> storage, SensorType sensorType, int interval)
    {
        var query = storage.Select(x => x.Value).Where(x =>
            (DateTime.Now - x.UpdateTime).Minutes <= interval && x.SensorType == sensorType);
        var sensorEvents = query as SensorEvent[] ?? query.ToArray();
        
        AvgTemperature = sensorEvents.Sum(x => x.Temperature) / sensorEvents.Length;
        AvgHumidity = sensorEvents.Sum(x => x.Humidity) / sensorEvents.Length;
        MinCO2 = sensorEvents.Select(x => x.CarbonDioxide).Min();
        MaxCO2 = sensorEvents.Select(x => x.CarbonDioxide).Max();
        AggregationTime = DateTime.Now;
    }

    public SensorsData()
    {
        
    }

    public override string ToString()
    {
        return $"AvgTemp: {AvgTemperature}\nAvgHumidity: {AvgHumidity}";
    }
}
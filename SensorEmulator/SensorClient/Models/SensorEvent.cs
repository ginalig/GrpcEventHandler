using System;

namespace SensorClient.Models;

public class SensorEvent
{
    public long Id { get; set; }
    
    public double Temperature { get; set; }
    
    public double Humidity { get; set; }
    
    public double CarbonDioxide { get; set; }
    
    public SensorType SensorType { get; set; }
    
    public DateTime UpdateTime { get; set; }
}
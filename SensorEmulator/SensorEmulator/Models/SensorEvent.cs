namespace SensorEmulator.Models;

public class SensorEvent : IEvent
{
    public long Id { get; set; }
    
    public double Temperature { get; set; }
    
    public double Humidity { get; set; }
    
    public double CarbonDioxide { get; set; }
    
    public SensorType SensorType { get; set; }
}
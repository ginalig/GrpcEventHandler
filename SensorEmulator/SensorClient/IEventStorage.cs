using SensorClient.Models;

namespace SensorClient;

public interface IEventStorage
{
    public void AddEvent(SensorEvent sensorEvent);

    public void RemoveEvent(long id);

    public SensorEvent GetById(long id);
}
using Microsoft.AspNetCore.Mvc;

namespace SensorEmulator.Controllers;

[Route("events")]
public class EventsController : ControllerBase
{
    private readonly IEventStorage _eventStorage;

    public EventsController(IEventStorage eventStorage)
    {
        _eventStorage = eventStorage;
    }
    
    [HttpGet]
    public Task<List<EventResponse>> GetLastEvents()
    {
        List<EventResponse> result = new();
        foreach (var @event in _eventStorage.LastEvents)
        {
            result.Add((EventResponse)@event);
        }
        return Task.FromResult(result);
    }
}
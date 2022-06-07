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
    public Task<EventResponse> GetLastEvent()
    {
        var eventResponse = (EventResponse)_eventStorage.LastEvent;
        return Task.FromResult(eventResponse);
    }
}
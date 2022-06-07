using System.Diagnostics.CodeAnalysis;

namespace SensorEmulator;

public interface IEventStorage
{
    bool TryGetEvent(long id, [MaybeNullWhen(false)] out IEvent eventResponse);
    void AddEvent(long id, IEvent eventResponse);
    IEvent LastEvent { get; }
}
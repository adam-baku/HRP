namespace HRP.Shared.Event;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent @event)
        where TEvent : IEvent;
    Task PublishAsync(IEnumerable<IEvent> events);
}

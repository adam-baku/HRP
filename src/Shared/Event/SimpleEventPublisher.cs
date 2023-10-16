
namespace HRP.Shared.Event;

public class SimpleEventPublisher(IEventHandlerLocator eventHandlerLocator) : IEventPublisher
{
    private readonly IEventHandlerLocator eventHandlerLocator = eventHandlerLocator;

    public async Task PublishAsync<TEvent>(TEvent @event)
        where TEvent : IEvent
    {
        foreach (var eventHandler in eventHandlerLocator.GetHandlers<TEvent>())
        {
            await eventHandler.HandleAsync(@event);
        }
    }

    public async Task PublishAsync(IEnumerable<IEvent> events)
    {
        foreach (IEvent @event in events) 
        {
            foreach (var eventHandler in eventHandlerLocator.GetHandlers(@event.GetType()))
            {
                await eventHandler.HandleAsync(@event);
            }
        }

    }
}

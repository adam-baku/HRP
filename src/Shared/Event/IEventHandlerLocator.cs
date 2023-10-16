namespace HRP.Shared.Event;

public interface IEventHandlerLocator
{
    IEnumerable<IEventHandler<TEvent>> GetHandlers<TEvent>()
        where TEvent : IEvent;
        
    IEnumerable<IEventHandler<IEvent>> GetHandlers(Type eventType);
}

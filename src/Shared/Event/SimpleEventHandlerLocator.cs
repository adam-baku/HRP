using Microsoft.Extensions.DependencyInjection;

namespace HRP.Shared.Event;

public class SimpleEventHandlerLocator(IServiceProvider serviceProvider) : IEventHandlerLocator
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    public IEnumerable<IEventHandler<TEvent>> GetHandlers<TEvent>()
        where TEvent : IEvent
    {
        return serviceProvider.GetServices<IEventHandler<TEvent>>();
    }

    public IEnumerable<IEventHandler<IEvent>> GetHandlers(Type eventType)
    {
        return (IEnumerable<IEventHandler<IEvent>>)serviceProvider
            .GetServices(typeof(IEventHandler<>).MakeGenericType(eventType));
    }
}

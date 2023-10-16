using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HRP.Shared.Event;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder RegisterEventBus(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventHandlerLocator, SimpleEventHandlerLocator>();
        builder.Services.AddScoped<IEventPublisher, SimpleEventPublisher>();

        return builder;
    }
}

using Microsoft.AspNetCore.Builder;

namespace HRP.Shared.Module;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        foreach (IModule module in ModuleLoader.Modules)
        {
            module.Register(builder);
        }

        return builder;
    }
}

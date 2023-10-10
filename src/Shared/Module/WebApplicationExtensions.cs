using Microsoft.AspNetCore.Builder;

namespace HRP.Shared.Module;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureModules(this WebApplication application)
    {
        foreach (IModule module in ModuleLoader.Modules)
        {
            module.Configure(application);
        }

        return application;
    }
}

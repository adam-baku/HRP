using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace HRP.Shared;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationPart(this IServiceCollection services, string moduleName)
    {
        return services.AddApplicationPart(AppDomain.CurrentDomain.GetAssemblies().First(x => x.FullName!.StartsWith(moduleName + ",")));
    }

    public static IServiceCollection AddApplicationPart(this IServiceCollection services, Assembly assembly)
    {
        var partManager = GetApplicationPartManager(services);
        
        partManager.ApplicationParts.Add(new AssemblyPart(assembly));

        return services;
    }
 
    private static ApplicationPartManager GetApplicationPartManager(IServiceCollection services)
    {
        return (ApplicationPartManager)services
            .Last(descriptor => descriptor.ServiceType == typeof(ApplicationPartManager))
            .ImplementationInstance;
    }
}

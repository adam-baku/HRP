using System.Collections.Immutable;
using System.Reflection;

namespace HRP.Shared.Module;

internal static class ModuleLoader
{
    internal static ImmutableList<IModule> Modules => modules ?? LocateModules() ?? [];

    private static ImmutableList<IModule>? modules;

    internal static ImmutableList<IModule> LocateModules()
    {
        var modulesTmp = new List<IModule>();

        foreach (var moduleAssembly in ModuleLocator.FindModules())
        {
            if (moduleAssembly.GetCustomAttribute(typeof(HrpModuleAttribute<>)) is IModuleCreator attribute) {
                modulesTmp.Add(attribute.Create());
            }
        }

        modules = [.. modulesTmp];

        return modules;
    }
}

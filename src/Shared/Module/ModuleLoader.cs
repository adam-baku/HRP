using System.Collections.Immutable;
using System.Reflection;

namespace HRP.Shared;

internal static class ModuleLoader
{
    internal static ImmutableList<IModule> Modules => modules ?? LocateModules() ?? [];

    private static ImmutableList<IModule>? modules;

    internal static ImmutableList<IModule> LocateModules()
    {
        var modulesTmp = new Dictionary<int, IModule>();

        foreach (var moduleAssembly in ModuleLocator.FindModules())
        {
            if (moduleAssembly.GetCustomAttribute(typeof(HrpModuleAttribute<>)) is IModuleCreator attribute) {
                modulesTmp.Add(attribute.Order, attribute.Create());
            }
        }

        modules = modulesTmp.OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToImmutableList();

        return modules;
    }
}

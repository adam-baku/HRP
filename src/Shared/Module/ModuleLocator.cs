using System.Reflection;

namespace HRP.Shared;

internal static class ModuleLocator
{
    internal static IEnumerable<Assembly> FindModules()
    {
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "HRP.Module.*.Infrastructure.dll");

        foreach (var file in files)
        {
            yield return Assembly.LoadFrom(file);
        }
    }
}

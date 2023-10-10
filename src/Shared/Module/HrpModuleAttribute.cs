namespace HRP.Shared.Module;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public class HrpModuleAttribute<TModule> : Attribute, IModuleCreator
    where TModule : IModule, new()
{
    public TModule Instance => new();

    public HrpModuleAttribute() {}

    public IModule Create()
    {
        return Instance;
    }
}


public interface IModuleCreator
{
    IModule Create();
}
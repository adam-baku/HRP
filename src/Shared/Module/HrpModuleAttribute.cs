namespace HRP.Shared;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public class HrpModuleAttribute<TModule> : Attribute, IModuleCreator
    where TModule : IModule, new()
{
    public TModule Instance => new();
    public int Order { get; init; }

    public HrpModuleAttribute() : this(0) {}

    public HrpModuleAttribute(int order)
    {
        Order = order;
    }

    public IModule Create()
    {
        return Instance;
    }
}


public interface IModuleCreator
{
    int Order { init; get; }
    IModule Create();
}
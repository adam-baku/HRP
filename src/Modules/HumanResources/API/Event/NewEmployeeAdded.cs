using HRP.Shared.Event;

namespace HRP.Module.HumanResources.API.Event;

public record struct NewEmployeeAdded(int Id) : IEvent
{
    
}

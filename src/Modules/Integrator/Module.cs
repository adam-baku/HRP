using HRP.Module.HumanResources.API.Event;
using HRP.Module.Integrator.Event;
using HRP.Shared.Event;
using HRP.Shared.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

[assembly: HrpModule<HRP.Module.Integrator.Module>]

namespace HRP.Module.Integrator;

public class Module : IModule
{
    public void Configure(WebApplication application)
    {
        //do nothing
    }

    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEventHandler<NewEmployeeAdded>, NewEmployeeAddedHandler>();
    }
}

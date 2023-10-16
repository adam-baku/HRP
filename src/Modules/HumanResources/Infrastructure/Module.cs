using HRP.Shared.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HRP.Module.HumanResources.API.Database;
using HRP.Module.HumanResources.Infrastructure.Database;

[assembly: HrpModule<HRP.Module.HumanResources.Infrastructure.Module>]

namespace HRP.Module.HumanResources.Infrastructure;

public class Module : IModule
{
    public void Configure(WebApplication application)
    {
        //do nothing
    }

    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationPart("HRP.Module.HumanResources.API");
        builder.Services.AddDbContext<IEmployeeRepository, HumanResourcesDbContext>();
    }
}

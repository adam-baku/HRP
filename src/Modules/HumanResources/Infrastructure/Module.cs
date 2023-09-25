using HRP.Module.HumanResources.API;
using HRP.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HRP.Module.HumanResources.Infrastructure;

public class Module : IModule
{
    public void Configure(WebApplication application)
    {
        throw new NotImplementedException();
    }

    public void Register(WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationPart("HRP.Module.HumanResources.API");
        builder.Services.AddDbContext<IEmployeeRepository, HumanResourcesDbContext>();
    }
}

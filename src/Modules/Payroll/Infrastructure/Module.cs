using HRP.Shared;
using Microsoft.AspNetCore.Builder;

[assembly: HrpModule<HRP.Module.Payroll.Infrastructure.Module>]

namespace HRP.Module.Payroll.Infrastructure;

public class Module : IModule
{
    public void Configure(WebApplication application)
    {
        //do nothing
    }

    public void Register(WebApplicationBuilder builder)
    {
        //do nothing
    }
}

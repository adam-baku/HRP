using HRP.Module.Payroll.Application.Command;
using HRP.Module.Payroll.Domain.Service;
using HRP.Shared.Command;
using HRP.Shared.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

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
        builder.Services.AddScoped<SalaryService>();
        builder.Services.AddScoped<ICommandHandler<AddObligationCommand>, AddObligationCommandHandler>();
    }
}

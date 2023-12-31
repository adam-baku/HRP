﻿using Microsoft.AspNetCore.Builder;

namespace HRP.Shared.Module;

public interface IModule
{
    void Configure(WebApplication application);
    void Register(WebApplicationBuilder builder);
}

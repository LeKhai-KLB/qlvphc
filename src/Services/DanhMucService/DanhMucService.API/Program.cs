using Common.Logging;
using Contracts.Common.Interfaces;
using DanhMucService.API.Extensions;
using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using DanhMucService.Application;
using DanhMucService.Infrastructure;
using DanhMucService.Infrastructure.Persistence;
using HealthChecks.UI.Client;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
Log.Information($"Start {builder.Environment.ApplicationName} Api up");

// Add services to the container.

try
{
    builder.Host.AddAppConfigurations();
    
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Services.AddControllers(
        opt =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
    builder.Services.AddScoped<ISerializeService, SerializeService>();
    builder.Services.AddSingleton<Stopwatch>(new Stopwatch());

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "QLVPHC", Version = "v1" });

        // Define the security scheme
        // TODO
        // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        // {
        //     Type = SecuritySchemeType.Http,
        //     BearerFormat = "JWT",
        //     In = ParameterLocation.Header,
        //     Scheme = "bearer"
        // });

        // Define the security requirement
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    });
    builder.Services.AddApplicationServices();
    builder.Services.AddConfigurationSettings(builder.Configuration);
    builder.Services.ConfigureCors(builder.Configuration);
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.ConfigureHealthChecks(builder.Configuration);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseCors("CorsPolicy");

    using (var scope = app.Services.CreateScope())
    {
        var eyeClinicContextSeed = scope.ServiceProvider.GetRequiredService<DanhMucServiceContextSeed>();
        await eyeClinicContextSeed.InitializeAsync();
    }
    app.UseRouting();
    //app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        endpoints.MapDefaultControllerRoute();
    });

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if(type.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;
    Log.Fatal(ex, "Unhanded exception");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} API complete");
    Log.CloseAndFlush();
}
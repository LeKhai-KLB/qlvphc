using Common.Logging;
using Contracts.Common.Interfaces;
using CatalogService.API.Extensions;
using Infrastructure.Common;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics;
using CatalogService.Application;
using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Persistence;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Extensions;
using static Shared.Common.Constants.Permissions;
using Microsoft.IdentityModel.Logging;

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);
Log.Information($"Start {builder.Environment.ApplicationName} Api up");

// Add services to the container.
try
{
    IdentityModelEventSource.ShowPII = true;

    builder.Host.AddAppConfigurations();
    
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Services.AddControllers();
    // builder.Services.AddControllers(
    //     opt =>
    //     {
    //         var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    //         opt.Filters.Add(new AuthorizeFilter(policy));
    //     })
    //     .AddJsonOptions(options =>
    //     {
    //         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    //     });
    builder.Services.AddScoped<ISerializeService, SerializeService>();
    builder.Services.AddSingleton<Stopwatch>(new Stopwatch());

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "QLVPHC", Version = "v1" });

        // Define the security scheme`
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Scheme = "bearer"
        });

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

    //Authentication
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(option =>
    {
        option.SaveToken = true;
        option.TokenValidationParameters = new TokenValidationParameters
        {
            SaveSigninToken = true,
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],       // Jwt:Issuer - config value 
            ValidAudience = builder.Configuration["Jwt:Audience"],     // Jwt:Issuer - config value 
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // Jwt:Key - config value 
        };
    });

    //Authorization
    builder.Services.AddAuthorization(options =>
    {
        options.AddPermissionPolicies<Users>();
        options.AddPermissionPolicies<LinhVucXuPhats>();
        options.AddPermissionPolicies<ChiTietLinhVucXuPhats>();
        options.AddPermissionPolicies<CoQuanBanHanhs>();
        options.AddPermissionPolicies<LoaiVanBans>();
        options.AddPermissionPolicies<VanBanGiaiQuyets>();
        options.AddPermissionPolicies<VanBanPhapLuats>();
        options.AddPermissionPolicies<VanBanLienQuans>();
        options.AddPermissionPolicies<ThamQuyenXuPhats>();
        options.AddPermissionPolicies<CoQuans>();
        options.AddPermissionPolicies<CongDans>();
        options.AddPermissionPolicies<DieuKhoanBoSungKhacPhucs>();
        options.AddPermissionPolicies<HoSoXuLyViPhams>();
        options.AddPermissionPolicies<HSVPVanBanGiaiQuyets>();
        options.AddPermissionPolicies<HanhViViPhams>();
        options.AddPermissionPolicies<DieuKhoanXuPhats>();
        options.AddPermissionPolicies<ChiTietHSXLVPVVBGQs>();
        options.AddPermissionPolicies<ToChucs>();
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
        var qlvphcContextSeed = scope.ServiceProvider.GetRequiredService<CatalogServiceContextSeed>();
        await qlvphcContextSeed.InitializeAsync();
        //await qlvphcContextSeed.TrySeedCongDanAsync();
        await qlvphcContextSeed.TrySeedToChucAsync();
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
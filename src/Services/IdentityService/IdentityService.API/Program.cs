using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using IdentityService.Infrastructure.Persistence;
using Serilog;
using Common.Logging;
using System.Diagnostics;
using IdentityService.Infrastructure;
using IdentityService.Application;
using IdentityService.Application.Common.Interfaces;
using IdentityService.API.Services;
using IdentityService.API.Seeds;
using IdentityService.API.Extensions;
using static Shared.Common.Constants.Permissions;
using IdentityService.Infrastructure.Permission;
using IdentityService.Domain.Entities;
using Infrastructure.Extensions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

Log.Information($"Start {builder.Environment.ApplicationName} Api up");

try
{
    var _config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json").Build();

    builder.Services.AddInfrastructureServices(_config);
    builder.Services.AddApplicationServices();

    //Registering Identity 
    builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

    builder.Host.UseSerilog(Serilogger.Configure);

    //Registering Mail Service
    builder.Services.Configure<MailSettings>(_config.GetSection("MailSettings"));

    builder.Services.AddControllers();
    
    builder.Services.AddSingleton<Stopwatch>(new Stopwatch());

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureCors(builder.Configuration);
    builder.Services.ConfigureHealthChecks(builder.Configuration);

    builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
    builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

    //Registering Interface
    builder.Services.AddScoped<IAuthService, AuthService>();
    builder.Services.AddTransient<IMailService, MailService>();

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
        options.AddPermissionPolicies<KhoBacs>();
        options.AddPermissionPolicies<KetQuaXuPhatHanhChinhs>();
        options.AddPermissionPolicies<KetQuaXuPhatTruyCuuHSs>();
    });

    //Swagger
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "QLVPHC-IdentityService-API",
            Version = "v1"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
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
            ValidIssuer = _config["Jwt:Issuer"],       // Jwt:Issuer - config value 
            ValidAudience = _config["Jwt:Audience"],     // Jwt:Issuer - config value 
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"])) // Jwt:Key - config value 
        };
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("CorsPolicy");

    using (var scope = app.Services.CreateScope())
    {
        var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (_context != null)
        {
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }
        }

        var services = scope.ServiceProvider;
        try
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await DefaultRoles.SeedAsync(userManager, roleManager);
            await DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
            await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);

            Log.Information($"Finished Seeding Default Data of {builder.Environment.ApplicationName} API");
        }
        catch (Exception ex)
        {
            Log.Warning(ex, $"An error occurred seeding the DB of {builder.Environment.ApplicationName} API");
        }
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;

    Log.Fatal(ex, "Unhanded exception");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} API complete");
    Log.CloseAndFlush();
}
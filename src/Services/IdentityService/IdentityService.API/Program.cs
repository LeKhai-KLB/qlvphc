using IdentityService.API.Constants;
using IdentityService.API.Data;
using IdentityService.API.Permission;
using IdentityService.API.Repository;
using IdentityService.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using SendGrid.Helpers.Mail;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using IdentityService.API.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var _config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddDbContext<ApplicationDbContext>();

//Registering Identity 
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

//Registering Mail Service
builder.Services.Configure<MailSettings>(_config.GetSection("MailSettings"));

//Registering Interface
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

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
        ValidAudience = _config["Jwt:Issuer"],     // Jwt:Issuer - config value 
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"])) // Jwt:Key - config value 
    };
});

//Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Permissions.Users.View, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.View));
    });

    options.AddPolicy(Permissions.Users.Create, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.Create));
    });

    options.AddPolicy(Permissions.Users.Edit, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.Edit));
    });

    options.AddPolicy(Permissions.Users.Delete, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.Delete));
    });

    options.AddPolicy(Permissions.Users.viewById, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.viewById));
    });

    options.AddPolicy(Permissions.Users.SuperAdminView, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.SuperAdminView));
    });

    options.AddPolicy(Permissions.Users.SuperAdminCreate, builder =>
    {
        builder.AddRequirements(new PermissionRequirement(Permissions.Users.SuperAdminCreate));
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Seeding logic
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
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("app");

    try
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
        await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);

        logger.LogInformation("Finished Seeding Default Data");
    }
    catch (Exception ex)
    {
        logger.LogWarning(ex, "An error occurred seeding the DB");
    }
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
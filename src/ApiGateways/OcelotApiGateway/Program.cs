using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

var logFactory = new LoggerFactory().CreateLogger<Type>();
logFactory.LogInformation("ApiGateway started!");
logFactory.LogInformation("EnrironmentName:" + builder.Environment.EnvironmentName);
app.Run();
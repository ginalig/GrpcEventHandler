using Microsoft.AspNetCore.Server.Kestrel.Core;
using SensorEmulator;
using SensorEmulator.Options;
using SensorEmulator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    // Setup a HTTP/2 endpoint without TLS.
    options.ListenLocalhost(7290, o => o.Protocols =
        HttpProtocols.Http2);
    options.ListenLocalhost(7250, o => o.Protocols = HttpProtocols.Http1);
});

builder.Services.Configure<SensorConfig>(builder.Configuration.GetSection("SensorConfig"));

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<IEventStorage, EventStorage>();
builder.Services.AddMvcCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseEndpoints(b =>
{
    b.MapControllers();
    b.MapGrpcService<GeneratorService>();
});

app.Run();
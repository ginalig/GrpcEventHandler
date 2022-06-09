using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SensorClient.HostedServices;
using SensorClient.Options;

namespace SensorClient
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;

        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ClientConfig>(_configuration.GetSection("ClientConfig"));

            services.AddGrpcClient<SensorEmulator.EventGenerator.EventGeneratorClient>(o =>
            {
                o.Address = new Uri("http://localhost:7290");
            });
            services.AddHostedService<SensorHostedService>();
            services.AddSingleton<IEventStorage, EventStorage>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> looger)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}
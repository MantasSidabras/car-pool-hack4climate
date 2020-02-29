using CarPool.Trip.Application.Event.Queries;
using CarPool.Trip.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace CarPool.Trip.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(options =>
                {
                    options.AddDbContext<TripDbContext>();

                    options.AddMediatR(typeof(GetAllEvents).GetTypeInfo().Assembly);
                });
    }
}

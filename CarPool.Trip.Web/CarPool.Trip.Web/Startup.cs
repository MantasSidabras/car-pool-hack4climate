using CarPool.Trip.Domain.Entities;
using CarPool.Trip.Persistence;
using CarPool.Trip.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CarPool.Trip.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionToResponseMappingFilter));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetService<TripDbContext>())
            {
                context.Database.Migrate();
                if (context.Events.CountAsync().GetAwaiter().GetResult() == 0) 
                {
                    context.Events.Add(new Event
                    {
                        Id = 1,
                        EventName = "Hack4Climate",
                        Description = "#Hack4Climate dalyvauti kviečiame IT sektoriaus profesionalus, dizainerius, viešųjų ryšių specialistus, teisininkus, architektus, inžinierius, mokytojus, studentus, moksleivius ir visus kitus, kuriuos domina ekologiškos technologijos ir tvarūs sprendimai.",
                        Address = "Gedimino pr. 16, 01103 Vilnius, Lithuania",
                        EventTime = new DateTime(2020, 03, 01, 9, 0, 0),
                        LogoUri = "https://scontent.fvno5-1.fna.fbcdn.net/v/t1.0-9/82537611_10157898834144233_5570923447380344832_o.jpg?_nc_cat=104&_nc_sid=b386c4&_nc_ohc=CeBE5E9omLcAX-UBwpW&_nc_ht=scontent.fvno5-1.fna&oh=fac56b3e335d3747ab7e8bf6dd258f2e&oe=5EFF9DD3"
                    });
                    context.SaveChanges(true);
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}

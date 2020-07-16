using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Contexts;
using CityInfo.API.Repositories;
using CityInfo.API.Services;
using CityInfo.API.Services.impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(); 
            services.AddSwaggerGen(); 

            var connectionString = @"Data Source=DESKTOP-0V8GDSH\SQLEXPRESS;Initial Catalog=CityInfoDB;Integrated Security=True";
            services.AddDbContext<CityInfoContext>(o=> {
                o.UseSqlServer(connectionString);
            }); 

           
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
            services.AddScoped<IPointsOfInterestRepository, PointsOfInterestRepository>();


           
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPointsOfInterestService, PointsOfInterestService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            
            app.UseStaticFiles(); 
            app.UseRouting();
            app.UseCors(); 
            app.UseStatusCodePages(); 
            app.UseRouting();
            app.UseSwagger(); 

            app.UseSwaggerUI(c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CityInfo API V1 ");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  
            });
        }
    }
}

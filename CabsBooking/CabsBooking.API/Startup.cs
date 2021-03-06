using CabsBooking.Core.Entities;
using CabsBooking.Core.RepositoryInterfaces;
using CabsBooking.Core.ServiceInterfaces;
using CabsBooking.Infrastructure.Data;
using CabsBooking.Infrastructure.Repostories;
using CabsBooking.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabsBooking.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CabsBooking.API", Version = "v1" });
            });

            services.AddDbContext<CabsBookingDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(("CabsBookingConnection"))));

            //Register our DI services...binding services to interfaces
            //also repository
            services.AddScoped<ICabService, CabService>();
            services.AddScoped<ICabRepository, CabRepository>();
            //services.AddScoped<IBHistoryRepository, BHistoryRepository>();
            //services.AddScoped<IPlaceRepository, PlaceRepository>();

            services.AddScoped<IBHistoryService, BHistoryService>();
            services.AddScoped<IBHistoryRepository,BHistoryRepository>();

            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CabsBooking.API v1"));
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins(Configuration.GetValue<string>("clientSPAUrl")).AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using UniversityApplication.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityApplication.Data;
using Microsoft.EntityFrameworkCore;
using UniversityApplication.Service.Interfaces;
using UniversityApplication.Service.Services;
using AutoMapper;
using UniversityApplication.Models.Profiles;
using UniversityApplication.Data.Repositories;
using UniversityApplication.Data.Interfaces;

namespace UniversityApplication.WebApi
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

            services.AddControllersWithViews();
            services.Configure<ConnectionSrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<IConfiguration>(Configuration);

            services
                .AddDbContextPool<UniversityDataContext>((serviceProvider, options) =>
                {
                    options
                        .UseSqlServer(Configuration.GetSection("ConnectionStrings")
                            .GetSection("DefaultConnection").Value,
                            x => x.MigrationsAssembly("UniversityApplication.Data"));
                    options
                        .UseInternalServiceProvider(serviceProvider);
                });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClubProfile());
                mc.AddProfile(new PlayerProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversityApplication.WebApi", Version = "v1" });
            });

            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IClubService, ClubService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityApplication.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
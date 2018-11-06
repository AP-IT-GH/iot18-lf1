using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Repositories;
using Services;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Use SQL Database if in Azure, otherwise, use SQLite
          /*  if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<CollectionContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
            else */
                services.AddDbContext<CollectionContext>(
                        options => options.UseSqlServer(
                 Configuration.GetConnectionString("MyDbConnection")));

            // Automatically perform database migration
            services.BuildServiceProvider().GetService<CollectionContext>().Database.Migrate();

            services.AddCors();
            services.AddMvc();

            //dependency injection
            services.AddScoped<PlantRepository>();
            services.AddScoped<SensorRepository>();
            services.AddScoped<LabFarmRepository>();
            services.AddScoped<SensorDataRepository>();
            services.AddScoped<PicturesRepository>();

            services.AddScoped<PlantService>();
            services.AddScoped<SensorService>();
            services.AddScoped<LabFarmService>();
            services.AddScoped<PictureService>();
            services.AddScoped<SensorDataService>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CollectionContext collectionContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                       builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();

            DBInitializer.Initialize(collectionContext);
        }
    }
}

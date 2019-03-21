using AcademyDocker.Adapter;
using AcademyDocker.Api.Metrics;
using AcademyDocker.Api.Middleware;
using AcademyDocker.Business;
using AcademyDocker.DataContract.Data.Settings;
using AcademyDocker.DataContract.Interfaces;
using AcademyDocker.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AcademyDocker.Api
{
    /// <summary>
    /// You are also starting up with ASP.NET Core?
    /// Check out this tutorial: https://docs.microsoft.com/en-us/aspnet/core/tutorials/?view=aspnetcore-2.1
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Basics
            services.Configure<AppSettings>(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IMetricsCollection, MetricsCollection>();

            services.AddAdapters();
            services.AddBusiness();
            services.AddRepositories();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "AcademyDocker-Service",
                    Version = "v1",
                    Description = "TODO: Add a qualified description in your Startup.cs nerd"
                });

                // Great documentation here: https://github.com/mattfrear/Swashbuckle.AspNetCore.Filters
                //options.OperationFilter<AddHeaderOperationFilter>("X-Roles", "Roles of client or user", true);
                //options.OperationFilter<AddHeaderOperationFilter>("X-Tenant", "Tenant of Client", true);
                //options.OperationFilter<AddHeaderOperationFilter>("X-Global-User-Id", "Global User Id");
                //options.OperationFilter<AddHeaderOperationFilter>("X-Client-Id", "Identifier of the calling client", true);
                //options.OperationFilter<AddHeaderOperationFilter>("X-Correlation-Id", "Correlation Id for tracing of this call");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseMiddleware<MetricCollectorMiddleware>();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AcademyDocker V1");
            });

            //If a unhandled exception occurs, this middleware returns a json result as required.
            app.UseMiddleware<JsonErrorHandlingMiddleware>();

            app.UseMvc();
        }
    }
}
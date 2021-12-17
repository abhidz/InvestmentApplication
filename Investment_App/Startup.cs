using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Investment_App.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using Investment_App.OktaAPI;
using static Investment_App.OktaAPI.OKTAConenctionAPISettings;
using System;

namespace Investment_App
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
            services.AddRazorPages();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.Configure<OKTAConenctionAPISettings>(OpenIdConnectNames.Okta, Configuration.GetSection("Okta:OpenIdConnectSettings"));
            services.Configure<OKTAConenctionAPISettings>(OpenIdConnectNames.Okta, Configuration.GetSection("Okta:OpenIdConnectClientSettings"));
            services.AddScoped<IApplicationContext, ApplicationContext>();
            ConfigureCorsServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureCorsServices(IServiceCollection services)
        {
            // TODO: tie CORS down to specific origins
            services.AddCors(
                options =>
                {
                    options.AddPolicy("AllowAllOrigins", builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
                });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using sample_app.Extensions;
using sample_app.Middlewares;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();// ACtivate all the object or service require to understand ctrl and views

            // Activate Objects from ProductInMemory Or ProductOracle
            //AddScoped : Per Request Object Creation
            services.AddScoped<IStoreRepository, ProductInMemoryRepository>();

            // Per Request : One Object :  DB Service Object ,Identity Service
            services.AddScoped<IRandomService, RandomService>(); // Activate
            services.AddScoped<IRandomWrapper, RandomWrapper>(); // Activate

            // All Request : Single Object .. In Memory Db  Or Shared DB
            //services.AddSingleton<IRandomService, RandomService>(); // Activate
            //services.AddSingleton<IRandomWrapper, RandomWrapper>(); // Activate

            // Transient : Calculation logic
            // Everytime it resolves :  it creates a new Object
            //services.AddTransient<IRandomService, RandomService>(); // Activate
            //services.AddTransient<IRandomWrapper, RandomWrapper>(); // Activate

            // Activat Automapper
            // In the Current Assembly
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Built In Middleware 
            // Serve  Static Files
            app.UseStaticFiles(); // Understand  wwwroot

            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider($"{env.ContentRootPath}/kashishwwwroot"),
                RequestPath = "/files"
            });

            // Extension Method : Best Practice
            app.UseRequestCulture();  // Culture Set it to What we passed

            // Next Middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"Hello :  + { CultureInfo.CurrentCulture.DisplayName}");
            //});




            //// Using Use and Run Method to Create Middleware
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("First Middleware");
            //    await next.Invoke();
            //});            

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Second Middleware");
            //    await next.Invoke();
            //});

            // Circuit Breaker :  Next Middleware will not be called.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Broken   the Execution");
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Default URL :   http://localhost/home/details/1
                endpoints.MapDefaultControllerRoute(); // routing  ..
                
            });

        }
    }
}

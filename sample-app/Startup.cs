using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
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
                // Default URL :   http://localhost/home/index
                endpoints.MapDefaultControllerRoute(); // routing  ..
                
            });
        }
    }
}

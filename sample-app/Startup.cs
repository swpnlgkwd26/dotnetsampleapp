using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using sample_app.Extensions;
using sample_app.Middlewares;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app
{
    public class Startup
    {

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // Talk to appsetting and get the connectionString
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();// ACtivate all the object or service require to understand ctrl and views

            // Activate Objects from ProductInMemory Or ProductOracle
            //AddScoped : Per Request Object Creation
            //services.AddScoped<IStoreRepository, ProductInMemoryRepository>();
            services.AddScoped<IStoreRepository, ProductSQLRepository>();
            services.AddScoped<ICustomerRespository, CustomerSQLRespository>();
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

            // Pass Connection String to Data Context
            services.AddDbContext<TataPowerDataContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:ProductConnection"]);
            });

            // Activate IFileProvider
            IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            services.AddSingleton<IFileProvider>(physicalProvider);


            // Configure Identity System
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TataPowerDataContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // We can execute code specific to environment
            if (env.IsDevelopment())
            {
                // Show Developer Exception Page
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging() || env.IsProduction())
            {
                // Show Custom Error Page
                app.UseExceptionHandler("/error"); //ctrl:error action :index

            }
            app.UseStatusCodePages();
            // Built In Middleware 
            // Serve  Static Files
            app.UseStaticFiles(); // Understand  wwwroot // FileProvider


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider($"{env.ContentRootPath}/kashishwwwroot"),
                RequestPath = "/files"
            });

            // Extension Method : Best Practice
            app.UseRequestCulture();  // Culture Set it to What we passed

            // Routing Feature 2 Middlewares
            // 1. UseRouting :  Select best match route
            app.UseRouting();
            app.UseAuthentication(); // Identity is Enabled using UseAuthentication
            app.UseAuthorization();
            // 2. UseEndpoints : Contains Set of Endpoints
            app.UseEndpoints(endpoints =>
            {
                // Conventional Routing
                // http://localhost/Product/Page1 ..  http://localhost/Product/Page2
                // User is not passing category he wants to iterate over all the products pagination wise
                endpoints.MapControllerRoute("paginationcategory", "{category}/Page{productPage:int}", new
                {
                    controller = "Home",
                    action = "Index"
                });

                endpoints.MapControllerRoute("categorypage", "{category}", new
                {
                    controller = "Home",
                    action = "Index"
                });
              
                endpoints.MapControllerRoute("pagination", "Product/Page{productPage:int}", new
                {
                    controller = "Home",
                    action = "Index"
                });



                // How to Create your own route
                // Create Route Where User can pass Price as a parameter to the URL .that i want to print
                endpoints.MapGet("/productinfo/{price}", async (context) =>
                {
                    var productPrice = context.Request.RouteValues["price"];
                    await context.Response.WriteAsync("Hello  : " + productPrice);

                });

                endpoints.MapGet("/authorize/{username}", async (context) =>
                {
                    var userName = context.Request.RouteValues["username"];
                    await context.Response.WriteAsync("Hello  : " + userName);
                });

                // Request : By default :  Controller Name = home, action=Index
                endpoints.MapDefaultControllerRoute(); //home/index

            });

        }
    }
}

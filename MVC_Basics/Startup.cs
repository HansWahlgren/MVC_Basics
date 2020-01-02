using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVC_Basics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //add MVC so we can use it
            services.AddMvc();

            //services.AddMvc(options =>
            //{
            //    options.EnableEndpointRouting = false;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();  //Looks for index.html or default.html
            app.UseStaticFiles();   //default opens up the wwwroot folder to be accessed
            app.UseSession();
            app.UseRouting();

            // MVC routing instead of Endpoints
            //app.UseMvc(routes =>
            //{
            //    //  routes.MapRoute("testing", "{controller=GuessingGame}/{action=Index}/{id?}");
            //    routes.MapRoute("blog", "blog/{*article}",
            //        defaults: new { controller = "GuessingGame", action = "Index" });
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("GuessRoute", "GuessingGame",
                        defaults: new { controller = "GuessingGame", action = "Index" });
                endpoints.MapControllerRoute("FeverRoute", "FeverCheck",
                       defaults: new { controller = "FeverCheck", action = "Index" });
                endpoints.MapControllerRoute("PeopleRoute", "People",
                      defaults: new { controller = "People", action = "Index" });
                // Custom/special routes before default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                //    /*
                //    endpoints.MapGet("/", async context =>
                //    {
                //        await context.Response.WriteAsync("Hello World!");
                //    });
                //    */
            });
        }
    }
}

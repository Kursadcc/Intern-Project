using InternProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
//using Newtonsoft.Json;


namespace InternProject
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var connectionString = Configuration.GetConnectionString("InternProjectLocalDB");

            //Entity Framework  
            services.AddDbContext<InternProjectDBContext>(options => options.UseSqlServer(connectionString));
            services.AddControllersWithViews().AddControllersAsServices()
               //.AddNewtonsoftJson(options =>
               //{
               //    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
               //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               //}
               //)
               ;

            services.AddMvc();
            services.AddRazorPages()
                    .AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    // Cache static files for 30 days
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
                    ctx.Context.Response.Headers.Append("Expires", DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
                }
            });


            app.UseCookiePolicy();
            app.UseResponseCaching();
            //app.UseSession();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAcces;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Reflection;

namespace WebShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => o.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            services.AddDbContext<Context>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            var interfaceList = Assembly.Load(nameof(Service)).GetTypes().Where(o=>o.Name.StartsWith("I")).OrderBy(x=>x.Name).ToList();
            var serviceList = Assembly.Load(nameof(Service)).GetTypes().Where(o => !o.Name.StartsWith("I") && !o.IsNested).OrderBy(x=>x.Name).ToList();
            for(int i = 0; i< serviceList.Count; i++)
            {
                if(interfaceList[i].Name == "IOrdreService" || serviceList[i].Name == "OrdreService")
                {
                    services.AddScoped(interfaceList[i], serviceList[i]);
                }
                else if (interfaceList[i].Name == "ILoginStateService" || serviceList[i].Name == "LoginStateService")
                {
                    services.AddScoped(interfaceList[i], serviceList[i]);

                }
                else if (interfaceList[i].Name == "IPaypalApiService" || serviceList[i].Name == "PaypalApiService")
                {
                    services.AddScoped(interfaceList[i], serviceList[i]);
                }
                else
                {
                    services.AddTransient(interfaceList[i], serviceList[i]);
                }
            }
            services.AddTransient<WebAPI.Controllers.OrderController>();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace WebStore
{
    public class Startup
    {
        public  IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/tipofaday", async context =>
                {
                    context.Response.Headers.Append("content-type", "text/html; charset=utf-8");
                    var tips=new List<string> { "tip0","tip1","tip2" };
                    var tip = tips[new Random().Next(0, tips.Count)];
                              await context.Response
                                  .WriteAsync($"[{Configuration["TipOfTheDay:" + tip + ":header"]}]<br>{Configuration["TipOfTheDay:"+ tip + ":content"]}<br><a href='/'>Home</a> | <a href='/Home/Humans'>׳כוםû סולüט</a>");

                });

                endpoints.MapControllerRoute(
                    "default", 
                    "{controller=Home}/{action=Index}/{Id?}"
                    );
            });
        }
    }
}

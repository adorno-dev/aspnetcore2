using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCore2.Mvc.ViewComponents.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore2.Mvc.ViewComponents
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) =>
        services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase("fakeDatabase"))
                .AddScoped<TodoContext>()
                .RazorEngineAsLowerCase()
                .AddMvc();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=todo}/{action=index}/{id?}"));

            TodoSeed.Initialize(app.ApplicationServices);
        }
    }
}

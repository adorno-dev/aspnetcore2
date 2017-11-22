using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aspnet.Core.Filters.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore2.Mvc.Filters
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RazorEngineAsLowerCase();
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader", "Result filter added to MvcOptions.Filters")); // an instance
                options.Filters.Add(typeof(SampleActionFilter)); // by type
                //options.Filters.Add(new SampleGlobalActionFilter()); // an instance
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => routes.MapRoute("default", "{controller=Sample}/{action=SomeResource}"));
        }
    }
}

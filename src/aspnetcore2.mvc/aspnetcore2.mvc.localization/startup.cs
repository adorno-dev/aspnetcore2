using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using AspnetCore2;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace AspnetCore2.Mvc.Localization
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
            => services.RazorEngineAsLowerCase()
                       .AddLocalization(src => src.ResourcesPath = "resources")
                       .AddSingleton<IHtmlLocalizerFactory, HtmlLocalizerFactory>()
                       .AddSingleton<IViewLocalizer, ViewLocalizer>()
                       .AddMvc()
                       .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                       .AddDataAnnotationsLocalization();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var cultures = new [] {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR")
            };

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseRequestLocalization(new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            });
            
            app.UseMvcWithDefaultRoute();
        }
    }
}

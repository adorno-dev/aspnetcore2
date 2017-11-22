using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Razor.Pages.Data;
using Microsoft.Extensions.Configuration;
using AspnetCore2.Mvc.Razor.Conventions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using AspnetCore2.Mvc.Filters;
using AspnetCore2.Mvc.Razor.Features;

namespace AspnetCore2.Mvc.Razor
{
    public class Startup
    {
        private readonly IConfiguration _configuration = null;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.RazorEngineAsLowerCase()
                    .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("sample"))
                    .AddMvc()
                    .AddRazorPagesOptions(options =>
                    {
                        // template individual por paginas #1
                        options.Conventions.Add(new GlobalTemplatePageRouteModelConvention());
                        // template global utilizando filtros #2
                        options.Conventions.Add(new GlobalHeaderPageApplicationModelConvention());
                        // utilizando rotas/templates em razor pages para uma pasta específica #3
                        options.Conventions.AddFolderRouteModelConvention("/others", model =>
                        {
                            var selectorCount = model.Selectors.Count;
                            for (int i = 0; i < selectorCount; i++)
                            {
                                var selector = model.Selectors[i];
                                model.Selectors.Add(new SelectorModel
                                {
                                    AttributeRouteModel = new AttributeRouteModel 
                                    { 
                                        Order = 1,
                                        Template = AttributeRouteModel.CombineTemplates(selector.AttributeRouteModel.Template, "{otherPagesTemplate?}")
                                    }
                                });
                            }
                        });
                        // aplicação para uma página específica #4 
                        options.Conventions.AddPageRouteModelConvention("/about", model =>
                        {
                            var selectorCount = model.Selectors.Count;
                            for (int i = 0; i < selectorCount; i++)
                            {
                                var selector = model.Selectors[i];
                                model.Selectors.Add(new SelectorModel
                                {
                                    AttributeRouteModel = new AttributeRouteModel 
                                    { 
                                        Order = 1,
                                        Template = AttributeRouteModel.CombineTemplates(selector.AttributeRouteModel.Template, "{aboutTemplate?}")
                                    }
                                });
                            }
                        });
                        // aplicação de uma rota especifica para um path específico #5
                        options.Conventions.AddPageRoute("/contact", "thecontact/{text?}");
                        // aplicação global para uma determinada pasta #6 (similar ao exemplo #2)
                        options.Conventions.AddFolderApplicationModelConvention("/others", model => model.Filters.Add(
                            new AddHeaderAttribute("OtherPagesHeader", new[] { "OtherPages Header Value" })
                        ));
                        // mesma aplicacao para uma rota específica #7
                        options.Conventions.AddPageApplicationModelConvention("/about", model => model.Filters.Add(
                            new AddHeaderAttribute("AboutHeader", "About Header Value")
                        ));
                        // configuração de filtros #8
                        options.Conventions.ConfigureFilter(model =>
                        {
                                if (model.RelativePath.Contains("others/page2"))
                                    return new AddHeaderAttribute("OtherPagesPage2Header", "others/page2 Header Value");
                                return new EmptyFilter();
                        });
                        // configurando um filter factory #9
                        options.Conventions.ConfigureFilter(new AddHeaderWithFactory());
                    });

                    // .AddRazorPagesOptions(options => // customizando o path das razor pages
                    // {
                    //     options.RootDirectory = "mypages";
                    //     options.Conventions.AuthorizeFolder("/mypages/admin");
                    // })
                    // .WithRazorPagesAtContentRoot() // especifica que a raiz do razor page é raiz do app
                    // .WithRazorPagesRoot("/pages"); // especifica que as razor pages estao em um diretorio raiz customizado

                    // customizando os handlers para razor pages
                    services.AddSingleton<IPageApplicationModelProvider, CustomPageApplicationModelProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            => app.UseStaticFiles()
                  .UseMvc();
    }
}
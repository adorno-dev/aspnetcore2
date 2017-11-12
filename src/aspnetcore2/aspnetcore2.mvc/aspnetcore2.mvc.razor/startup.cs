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

namespace AspnetCore2.Mvc.Razor
{
    public class Startup
    {
        private readonly IConfiguration _configuration = null;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
            => services.RazorEngineAsLowerCase()
                       .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("sample"))
                       .AddMvc()
                       .AddRazorPagesOptions(options =>
                       {
                           // template individual por paginas
                           options.Conventions.Add(new GlobalTemplatePageRouteModelConvention());
                           // template global utilizando filtros
                           options.Conventions.Add(new GlobalHeaderPageApplicationModelConvention());
                           // utilizando rotas/templates em razor pages para uma pasta específica
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
                           // aplicação para uma página específica
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
                           // aplicação de uma rota especifica para um path específico
                           options.Conventions.AddPageRoute("/contact", "thecontact/{text?}");
                       });

                        // .AddRazorPagesOptions(options => // customizando o path das razor pages
                        // {
                        //     options.RootDirectory = "mypages";
                        //     options.Conventions.AuthorizeFolder("/mypages/admin");
                        // })
                        // .WithRazorPagesAtContentRoot() // especifica que a raiz do razor page é raiz do app
                        // .WithRazorPagesRoot("/pages"); // especifica que as razor pages estao em um diretorio raiz customizado

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            => app.UseStaticFiles()
                  .UseMvc();
    }
}

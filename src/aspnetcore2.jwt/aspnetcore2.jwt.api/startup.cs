using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using AspnetCore2.Jwt.Api.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AspnetCore2.Jwt.Api
{
    public class Startup
    {
        private readonly TokenOptions tokenOptions = new TokenOptions("s3cr3t.k3y1234567890", "1ssU3r", "4UD13NC3"); 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AsLowerCaseLocation()
                    .SetAuthentication()
                    .SetJwtTokenBearer(tokenOptions)
                    .SetAuthorization()
                    .AddMvc(options =>
                    {
                        /* Json Settings */
                        var jsonFormatterSettings = new JsonSerializerSettings 
                        { 
                            ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                            Formatting = Formatting.Indented
                        };

                        /* Json Formatter */
                        var jsonFormatter = new JsonOutputFormatter(jsonFormatterSettings, System.Buffers.ArrayPool<char>.Shared);

                        /* Main Policy */
                        var jwtBearer = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                                           .RequireAuthenticatedUser()
                                           .Build();
                        
                        options.Filters.Add(new AuthorizeFilter(policy: jwtBearer));

                        /* JSON Only */
                        options.OutputFormatters.Clear();
                        options.OutputFormatters.Add(jsonFormatter);
                    });
            
            services.AddSingleton(tokenOptions);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            /* Enable Cors */
            app.UseCors(cors =>
            {
                cors.AllowAnyHeader();
                cors.AllowAnyMethod();
                cors.AllowAnyOrigin();
            });

            /* Status Code Threatment */
            app.UseStatusCodePages(async context => await context.HttpCodeMessage());
            
            app.UseMvc(m => m.MapRoute(name: "default", template: "{controller=api}/{action=index}"));
        }
    }
}

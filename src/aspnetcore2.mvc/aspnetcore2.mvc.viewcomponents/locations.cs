using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.IO;

namespace AspnetCore2
{
    public static class CustomLowerCaseExtensions
    {
        public static IServiceCollection RazorEngineAsLowerCase(this IServiceCollection services)
        {
            // for MVC 
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Clear();
                options.FileProviders.Clear();

                options.ViewLocationExpanders.Add(new LowerCaseLocationExpander());
                options.FileProviders.Add(new LowerCaseFileProvider());
            });

            // for Razor Pages
            services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/pages");

            return services;
        }

        public class LowerCaseLocationExpander : IViewLocationExpander
        {
            public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
                => viewLocations.Select(s => s.Replace(s, s.ToLower()));

            public void PopulateValues(ViewLocationExpanderContext context) { }
        }

        public class LowerCaseFileProvider : IFileProvider
        {
            private readonly PhysicalFileProvider _provider = null;

            public LowerCaseFileProvider()
                => _provider = new PhysicalFileProvider(Environment.CurrentDirectory);

            public IDirectoryContents GetDirectoryContents(string subpath)
                => _provider.GetDirectoryContents(subpath.ToLower());

            public IFileInfo GetFileInfo(string subpath)
                => _provider.GetFileInfo(subpath.ToLower());

            public IChangeToken Watch(string filter)
                => _provider.Watch(filter.ToLower());
        }
    }
}
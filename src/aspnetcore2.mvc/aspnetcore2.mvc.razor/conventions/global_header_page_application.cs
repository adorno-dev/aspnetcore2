using AspnetCore2.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspnetCore2.Mvc.Razor.Conventions
{
    /// <summary>
    /// IPageApplicationModel
    /// Exemplo que ilustra uma aplicação global na construção das páginas utilizando filtro.
    /// </summary>
    public class GlobalHeaderPageApplicationModelConvention : IPageApplicationModelConvention
    {
        public void Apply(PageApplicationModel model)
            => model.Filters.Add(new AddHeaderAttribute("GlobalHeader", new [] { "Global Header Value" }));
    }
}
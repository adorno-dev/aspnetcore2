using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspnetCore2.Mvc.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ReplaceRouteValueFilterAttribute : Attribute, IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            // Chamado depois que o método é executado, antes do resultado
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            // Chamado antes que o método seja executado, depois de completo o processamento do model binding
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            // Chamado depois que um manipulador de método é selecionado, mas antes de ocorrer o model binding
            context.RouteData.Values.TryGetValue("globalTemplate", out var globalTemplateValue);
            if (string.Equals((string)globalTemplateValue, "TriggerValue", StringComparison.Ordinal))
                context.RouteData.Values["globalTemplate"] = "ReplacementValue";
        }
    }
}
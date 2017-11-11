using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspnetCore2.Mvc.Razor.Conventions
{
    public class GlobalTemplatePageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            var selectorCount = model.Selectors.Count;
            for (int i = 0; i < selectorCount; i++)
            {
                var selector = model.Selectors[i];
                model.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Order = 0,
                        Template = AttributeRouteModel.CombineTemplates(selector.AttributeRouteModel.Template, "{globalTemplate?}")
                    }
                });
            }
        }
    }
}
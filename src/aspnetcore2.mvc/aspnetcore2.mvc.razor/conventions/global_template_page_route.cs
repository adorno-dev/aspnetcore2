using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AspnetCore2.Mvc.Razor.Conventions
{
    /// <summary>
    /// Implementa a classe IPageRouteModelConvention.
    /// Adiciona uma rota template para a PageModel.
    /// Esta classe deve ser instanciada no Startup como abaixo:
    /// .AddRazorPagesOptions(options => { options.Conventions.Add(new GlobalTemplatePageRouteModelConvention()) });
    /// 
    /// </summary>
    public class GlobalTemplatePageRouteModelConvention : IPageRouteModelConvention // PageRouteModel
    {
        /// <summary>
        /// Aplica a convenção que será aplicada durante a rota e construção das PageModel(s)
        /// </summary>
        /// <param name="model">Recebe a PageModel por injeção de dependência? ou metodo extendido?</param>
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
                        // A ordem das PageModel geralmente iniciam com Order = 1.
                        // Deixando esta convenção com Order = 0 informa que esta convenção deverá ser priorizada.
                        Order = 0, 
                        // Combina o template da PageModel com o novo template abaixo:
                        Template = AttributeRouteModel.CombineTemplates(
                            selector.AttributeRouteModel.Template, 
                            "{globalTemplate?}"
                        )
                    }
                });
            }
        }
    }
}
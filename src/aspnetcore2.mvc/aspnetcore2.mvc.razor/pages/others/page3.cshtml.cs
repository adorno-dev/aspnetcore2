using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetCore2.Mvc.Filters;

namespace Razor.Pages.Others
{
    [ReplaceRouteValueFilter]
    public class Page3Model : PageModel
    {
        public string Message { get; private set; }
        public string RouteDataGlobalTemplateValue { get; private set; }
        public string RouteDataOtherPagesTemplateValue { get; private set; }

        public void Get()
        {
            this.Message = "Your application page3 page.";

            if (this.RouteData.Values["globalTemplate"] != null)
                this.RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {this.RouteData.Values["globalTemplate"]}";

            if (RouteData.Values["otherPagesTemplate"] != null)
                this.RouteDataOtherPagesTemplateValue = $"Route data for 'otherPagesTemplate' was provided: {this.RouteData.Values["otherPagesTemplate"]}";
        }
    }
}
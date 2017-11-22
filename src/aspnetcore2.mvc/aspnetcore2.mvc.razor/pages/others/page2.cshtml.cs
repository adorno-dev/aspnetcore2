using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages.Others
{
    public class Page2Model : PageModel
    {
        public string Message { get; private set; }
        public string RouteDataGlobalTemplateValue { get; private set; }
        public string RouteDataOtherPagesTemplateValue { get; private set; }

        public void OnGet()
        {
            this.Message = "Your application Page2 page.";

            if (this.RouteData.Values["globalTemplate"] != null)
                this.RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {this.RouteData.Values["globalTemplate"]}";

            if (this.RouteData.Values["otherPagesTemplate"] != null)
                this.RouteDataOtherPagesTemplateValue = $"Route data for 'otherPagesTemplate' was provided: {this.RouteData.Values["otherPagesTemplate"]}";
        }
    }
}
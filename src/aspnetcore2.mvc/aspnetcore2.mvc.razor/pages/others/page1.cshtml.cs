using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages.Others
{
    public class Page1Model : PageModel
    {
        public string Message { get; private set; }

        public string RouteDataGlobalTemplateValue { get; private set; }

        public string RouteDataOtherPagesTemplateValue { get; private set; }

        public void OnGet()
        {
            this.Message = "Your application Page1 page.";

            if (this.RouteData.Values["globalTemplate"] != null)
                this.RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {RouteData.Values["globalTemplate"]}";
            
            if (this.RouteData.Values["otherPagesTemplate"] != null)
                this.RouteDataOtherPagesTemplateValue = $"Route data for 'otherPagesTemplate' was provided: {RouteData.Values["otherPagesTemplate"]}";
        }
    }
}
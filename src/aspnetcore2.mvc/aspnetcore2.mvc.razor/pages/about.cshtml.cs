using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; private set; }
        public string RouteDataGlobalTemplateValue { get; private set; }
        public string RouteDataAboutTemplateValue { get; private set; }

        public void OnGet() 
        {
            this.Message = "Your application description page.";

            if (this.RouteData.Values["globalTemplate"] != null)
                this.RouteDataGlobalTemplateValue = $"Route data for 'globalTemplate' was provided: {this.RouteData.Values["globalTemplate"]}";

            if (this.RouteData.Values["aboutTemplate"] != null)
                this.RouteDataAboutTemplateValue = $"Route data for 'aboutTemplate' was provided: {this.RouteData.Values["aboutTemplate"]}";
        }
    }
}
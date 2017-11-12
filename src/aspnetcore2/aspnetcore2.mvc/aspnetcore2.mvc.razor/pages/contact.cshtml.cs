using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages
{
    public class ContactModel : PageModel 
    {
        public string Message { get; private set; }

        public string RouteDataTextTemplateValue { get; private set; }

        public void OnGet()
        {
            Message = "Your contact page.";

            if (RouteData.Values["text"] != null)
                RouteDataTextTemplateValue = $"Route data for 'text' was provided: {RouteData.Values["text"]}";
        }
    }
}
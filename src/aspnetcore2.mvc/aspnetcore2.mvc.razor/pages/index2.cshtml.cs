using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Razor.Pages
{
    public class Index2Model : PageModel
    {
        public string Message { get; private set; } = "PageModel in C#";
        
        public void OnGet() => Message += $" Server Time Is {DateTime.Now}";
    }
}
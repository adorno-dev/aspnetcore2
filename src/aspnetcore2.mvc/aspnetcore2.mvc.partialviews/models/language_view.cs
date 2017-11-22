using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCore2.Mvc.PartialViews.Models
{
    public class LanguageViewModel
    {
        public string Language { get; set; }
        
        public IList<SelectListItem> Languages { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "en-US", Text = "English (United States)" },
            new SelectListItem { Value = "pt-BR", Text = "Portuguese (Brazilian)" },
        };
    }
}
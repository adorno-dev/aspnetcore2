using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCore2.Mvc.PartialViews.Models
{
    public class CountriesViewModel
    {
        public string Country { get; set; }

        public IList<SelectListItem> Countries { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "MX", Text = "Mexico" },
            new SelectListItem { Value = "CA", Text = "Canada" },
            new SelectListItem { Value = "US", Text = "United States" }
        };
    }
}
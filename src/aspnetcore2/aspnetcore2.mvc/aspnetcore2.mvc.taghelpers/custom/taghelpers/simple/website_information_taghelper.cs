using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

using Aspnet.Core.Mvc.Models;

namespace Aspnet.Core.Mvc.Custom.TagHelpers
{
    [HtmlTargetElement("website-info")]
    public class WebSiteInformationTagHelper : TagHelper
    {
        public WebSiteContext Info { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.Content.SetHtmlContent(
                $@"<ul>
                        <li><strong>Version:</strong>{Info.Version}</li>
                        <li><strong>Copyright Year:</strong>{Info.CopyrightYear}</li>
                        <li><strong>Approved:</strong>{Info.Approved}</li>
                        <li><strong>Number of tags to show:</strong>{Info.TagsToShow}</li>
                  </ul>
                ");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;

namespace Aspnet.Core.Mvc.Custom.TagHelpers
{
    [HtmlTargetElement("p")]
    public class AutoLinkerHttpTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var node = output.IsContentModified ? output.Content.GetContent() : (await output.GetChildContentAsync()).GetContent();

            // Find urls in the content and replace them with their anchor tag equivalent.
            output.Content.SetHtmlContent(Regex.Replace(node, @"\b(?:https?://)(\S+)\b", "<a target=\"_blank\" href=\"$0\">$0</a>")); // <<== http link version
        }

        // This filter must run before the AutoLinkerWwwTagHelper as it searches and replaces http and the AutoLinkerWwwTagHelper adds http to the markup.
        public override int Order => int.MinValue;
    }

    [HtmlTargetElement("p")]
    public class AutoLinkerWwwTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var node = output.IsContentModified ? output.Content.GetContent() : (await output.GetChildContentAsync()).GetContent();

            // Find urls in the content and replace them with their anchor tag equivalent.
            output.Content.SetHtmlContent(Regex.Replace(node, @"\b(www\.)(\S+)\b", "<a target=\"_blank\" href=\"http://$0\">$0</a>")); // <<== www link version
        }
    }

}

using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnet.Core.Mvc.Custom.TagHelpers
{
    //[HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
    public class EmailTagHelper : TagHelper
    {
        private const string emailDomain = "contoso.com";

        //// Can be passed via <email mail-to="..." />
        //public string MailTo { get; set; }

        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    var address = $"{this.MailTo}@{emailDomain}";
        //    output.TagName = "a"; // replaces <email> with <a> tag
        //    output.Attributes.SetAttribute("href", $"mailto:{address}");
        //    output.Content.SetContent(address);
        //}

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            var target = $"{content.GetContent()}@{emailDomain}".ToLower();

            output.TagName = "a"; // replace <email> with <a> tag
            output.Attributes.SetAttribute("href", $"mailto:{target}");
            output.Content.SetContent(target);
        }
    }
}

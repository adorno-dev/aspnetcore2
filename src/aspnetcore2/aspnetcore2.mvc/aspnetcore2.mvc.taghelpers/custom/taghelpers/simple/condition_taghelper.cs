using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Aspnet.Core.Mvc.Custom.TagHelpers
{
    [HtmlTargetElement(Attributes = nameof(Condition))]
    //[HtmlTargetElement(Attributes = "condition")]
    public class ConditionTagHelper : TagHelper
    {
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
                output.SuppressOutput();
        }
    }
}

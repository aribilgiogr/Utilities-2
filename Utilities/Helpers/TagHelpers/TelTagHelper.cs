using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Utilities.Helpers.TagHelpers
{
    [HtmlTargetElement("tel")]
    public class TelTagHelper : TagHelper
    {
        public required string Number { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"tel:{Number}");
            output.Content.SetContent(Number);
        }
    }
}

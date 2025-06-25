using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Utilities.Helpers.TagHelpers
{
    [HtmlTargetElement("email")]
    public class EmailTagHelper : TagHelper
    {
        public required string Address { get; set; }
        public string? Display { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{Address}");
            output.Content.SetContent(Display ?? Address);
        }
    }
}

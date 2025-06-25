using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Utilities.Helpers.TagHelpers
{
    [HtmlTargetElement("form-floating")]
    public class FormFloatingTagHelper : TagHelper
    {
        public required string Label { get; set; }
        public required string For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "form-floating");
            var html = $"""
                    <input type="email" class="form-control" id="{For}" placeholder="{Label}">
                    <label for="{For}">{Label}</label>
                """;
            output.Content.SetHtmlContent(html);
        }
    }
}

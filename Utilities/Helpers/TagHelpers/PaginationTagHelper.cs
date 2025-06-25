using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers.TagHelpers
{
    [HtmlTargetElement("pagination")]
    public class PaginationTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = default!;

        [HtmlAttributeName("page-model")]
        public dynamic? PageModel { get; set; }

        [HtmlAttributeName("page-action")]
        public string PageAction { get; set; } = string.Empty;

        [HtmlAttributeName("page-url-params")]
        public Dictionary<string, string>? PageUrlParams { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (PageModel == null || PageModel.TotalPages == 0) return;

            var urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "nav";
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination");

            var prev = CreatePageLink("Previous", PageModel.CurrentPage - 1, urlHelper);

            if (!PageModel.HasPreviousPage)
            {
                prev.AddCssClass("disabled");
            }
            ulTag.InnerHtml.AppendHtml(prev);

            for (int i = PageModel.Start; i <= PageModel.End; i++)
            {
                var li = CreatePageLink(i.ToString(), i, urlHelper);
                if(i == PageModel.CurrentPage)
                {
                    li.AddCssClass("active");
                }
                ulTag.InnerHtml.AppendHtml(li);
            }

            var next = CreatePageLink("Next", PageModel.CurrentPage + 1, urlHelper);
            if (!PageModel.HasNextPage)
            {
                next.AddCssClass("disabled");
            }
            ulTag.InnerHtml.AppendHtml(next);
            output.Content.AppendHtml(ulTag);
        }
        private TagBuilder CreatePageLink(string text, int page, IUrlHelper urlHelper)
        {
            var li = new TagBuilder("li");
            li.AddCssClass("page-item");

            var a = new TagBuilder("a");
            a.AddCssClass("page-link");
            a.Attributes["href"] = urlHelper.Action(PageAction, new { page });
            a.InnerHtml.Append(text);

            li.InnerHtml.AppendHtml(a);
            return li;
        }
    }
}

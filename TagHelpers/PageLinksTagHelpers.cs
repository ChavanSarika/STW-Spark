using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using  STW_Spark.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinksTagHelpers : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinksTagHelpers(IUrlHelperFactory _urlHelperFactory)
        {
            urlHelperFactory = _urlHelperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public PagingInfo pagemodel { get; set; }
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(viewContext);
            TagBuilder result = new TagBuilder("div");
            for(int i=1; i<=pagemodel.TotalItems;i++)
            {
                TagBuilder tag = new TagBuilder("a");
                string url = pagemodel.UrlParam.Replace(":", i.ToString());
                tag.Attributes["href"] = url;
                tag.AddCssClass(PageClass);
                tag.AddCssClass(i == pagemodel.CurrentPage ? PageClassSelected : PageClassNormal);
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}

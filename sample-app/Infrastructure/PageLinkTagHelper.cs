using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using sample_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Infrastructure
{
    // Custom tag helper that will generate Links
    [HtmlTargetElement("div",Attributes ="page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _helperFactory;

        // IURLHelperFactory class  to generate links
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _helperFactory = helperFactory;
        }

        // Need to Set ViewContext in order to gain access to Curent Context:  That is HttpContext, HttpRequest and HttpResponse

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        // Pagination Information
        public PagingInfo PageModel { get; set; }

        // Whenever i click on the Links it should go to Some Action
        public string  PageAction { get; set; }

        // Automatically called and will contain the Logic to Generate Links for us
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Current ITagHelper Information for the Request associated with  context
            IUrlHelper urlHelper =  _helperFactory.GetUrlHelper(ViewContext);
            // Build URLS
            TagBuilder result = new TagBuilder("div"); // Adds Div Tag : <div> <a href="pageno"> </a> <ahref="pageno2"> </a> </div>
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                // Generate Link
                TagBuilder tag = new TagBuilder("a"); // Generate anchor tag :<a href=""/>
                tag.Attributes["href"] =urlHelper.Action(PageAction, new { productPage=i}) ;
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml); // Holds the Output of TagHelper

        }

    }
}

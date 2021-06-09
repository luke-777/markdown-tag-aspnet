using Microsoft.AspNetCore.Razor.TagHelpers;
using Markdig;

namespace MarkdownTagExample.TagHelpers
{


    // Tag: <markdown md-content="@mymarkdown"/>
    [HtmlTargetElement("markdown", TagStructure = TagStructure.WithoutEndTag)] 
    public class MarkdownTagHelper : TagHelper
    {
        public string MdContent {get;set;}

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Markdown will be rendered between div
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetHtmlContent(Markdown.ToHtml(MdContent));
        }
    }
}
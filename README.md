# Markdown Tag for ASP.NET Core 5
Minimal Markdown Tag Helper for ASP.NET Core 5 
to render Markdown Content in our Views using [Markdig](https://github.com/xoofx/markdig).

## Preparations
Add following packages to our project:
```bash
dotnet add package markdig
dotnet add package Microsoft.AspNetCore.Mvc.TagHelpers
```

## Markdown Tag Helper
Create a new class that derives from TagHelper. You should create it in a folder called TagHelpers (see namespace). It will parse the Markdown and place the correspondenting HTML into a div-section.

```csharp
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
```

Add following imports to  ```_ViewImports.cshtml``` (MarkdownTagExample is your project name):
```csharp
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@addTagHelper *, MarkdownTagExample
```
## Usage
To render Markdown in our View add the tag to our view:
```csharp
@{
    ViewData["Title"] = "Home Page";
    var md = "# Test\n- Hello World!\n - Test";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>


<markdown md-content="@md"/>
```

The content of ```md``` will be rendered in this example.

Learn more at: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/authoring?view=aspnetcore-5.0
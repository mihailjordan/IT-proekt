#pragma checksum "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0b9451f64c5690c6a27d70406937e4816a688f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WorkSpace_ViewFile), @"mvc.1.0.view", @"/Views/WorkSpace/ViewFile.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\source\repos\INS_FInal\Views\_ViewImports.cshtml"
using INS_FInal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\INS_FInal\Views\_ViewImports.cshtml"
using INS_FInal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\source\repos\INS_FInal\Views\_ViewImports.cshtml"
using INS_FInal.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\source\repos\INS_FInal\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0b9451f64c5690c6a27d70406937e4816a688f9", @"/Views/WorkSpace/ViewFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46cf77d414f8fe4fb4de44da96149fcbe7952168", @"/Views/_ViewImports.cshtml")]
    public class Views_WorkSpace_ViewFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<INS_FInal.Models.File>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
   string filePath = "~/PublicFiles/" + (Model.FilePath);
    if (Model.IsPrivate)
    {
        filePath = "~/PrivateFiles/" + (Model.FilePath);
    }

    if (filePath.Contains(".mp4"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <video controls=\"controls\" width=\"900\">\r\n            <source");
            BeginWriteAttribute("src", " src=\"", 349, "\"", 377, 1);
#nullable restore
#line 16 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
WriteAttributeValue("", 355, Url.Content(filePath), 355, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"video/mp4\" />\r\n        </video>\r\n");
#nullable restore
#line 18 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"

    }
    else if (filePath.ToLower().Contains(".jpg") || filePath.ToLower().Contains(".png"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <img");
            BeginWriteAttribute("src", " src=\"", 536, "\"", 564, 1);
#nullable restore
#line 22 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
WriteAttributeValue("", 542, Url.Content(filePath), 542, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 23 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
    }
    else if (filePath.ToLower().Contains(".txt"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>&nbsp;</p>\r\n        <p>&nbsp;</p>\r\n        <div style=\"font-size:14px; border:dashed\">\r\n            <p>\r\n                <iframe");
            BeginWriteAttribute("src", " src=\"", 774, "\"", 802, 1);
#nullable restore
#line 30 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
WriteAttributeValue("", 780, Url.Content(filePath), 780, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" frameborder=\"0\" height=\"400\"\r\n                        style=\"width: 95%\"></iframe>\r\n            </p>\r\n        </div>\r\n");
#nullable restore
#line 34 "C:\Users\Admin\source\repos\INS_FInal\Views\WorkSpace\ViewFile.cshtml"
    }


#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<INS_FInal.Models.File> Html { get; private set; }
    }
}
#pragma warning restore 1591

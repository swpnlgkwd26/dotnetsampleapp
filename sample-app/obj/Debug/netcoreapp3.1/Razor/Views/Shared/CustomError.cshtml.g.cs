#pragma checksum "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\Shared\CustomError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5a3abe99bb6825cf4c1dcf6354602bff553e8d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_CustomError), @"mvc.1.0.view", @"/Views/Shared/CustomError.cshtml")]
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
#line 1 "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\_ViewImports.cshtml"
using sample_app.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\_ViewImports.cshtml"
using sample_app.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\_ViewImports.cshtml"
using Microsoft.Extensions.FileProviders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5a3abe99bb6825cf4c1dcf6354602bff553e8d7", @"/Views/Shared/CustomError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef796c0326ca06462f5c08a30fb440a56193efce", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_CustomError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\Shared\CustomError.cshtml"
  
    ViewData["Title"] = "Custom Error Page";
    var exception = ViewData["Exception"] as Exception;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>  An Error has occurred</h2>\r\n<p> ");
#nullable restore
#line 7 "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\Shared\CustomError.cshtml"
Write(exception.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

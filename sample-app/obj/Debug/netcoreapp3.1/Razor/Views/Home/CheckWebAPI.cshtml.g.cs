#pragma checksum "D:\FreeLancerAssignments\TataPower\dotnetcoreapp\sample-app\Views\Home\CheckWebAPI.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b09afcd7e6f86b901477e588db9210d72793370d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CheckWebAPI), @"mvc.1.0.view", @"/Views/Home/CheckWebAPI.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b09afcd7e6f86b901477e588db9210d72793370d", @"/Views/Home/CheckWebAPI.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2808b695109cead404ec139636cb14834b7bbf94", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CheckWebAPI : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h2> Connect to Web API</h2>

<button id=""btnGetProduct"" class=""btn btn-primary""> Get Product From API</button>
<input id=""productID""/>
<button id=""btnGetProductById"" class=""btn btn-primary""> Get Product From API By ID</button>
<ul id=""ulProducts"">
    
</ul>
<script type=""text/javascript"">
    $(document).ready(function () {

        // Take a Ref of UL 
        var ulProducts = $(""#ulProducts"");

        //Check if the button is clicked and if its clicked then it will call
        //API
        $(""#btnGetProduct"").click(function () {
            alert('Ajax Called');
            $.ajax({
                type: ""GET"",
                url: ""http://localhost:5001/api/Products"",
                dataType: ""json"",
                success: function (result) {                   
                    $.each(result, function (index, val) {
                        ulProducts.append(""<li>"" + val.name + ""</li>"");
                    })                   
                },
                erro");
            WriteLiteral(@"r: function (err) {
                    alert(""Not Found"");
                }
            });
        })

        $(""#btnGetProductById"").click(function () {
            var productId = $(""#productID"").val();
            $.ajax({
                type: ""GET"",
                url: ""http://localhost:5001/api/Products/"" + productId,
                dataType: ""json"",
                success: function (result) {   
                    console.log(result);
                    ulProducts.append(""<li>"" + result.productName + ""</li>"");                    
                },
                error: function (err) {
                    alert(""Not Found"");
                }
            })

        })
    })
</script>");
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
#pragma checksum "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcba1e6ce6ca6b3f604f2d26c5ab2aa9c1bb1568"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ViewMensagem), @"mvc.1.0.view", @"/Views/Shared/ViewMensagem.cshtml")]
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
#line 1 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\_ViewImports.cshtml"
using BackOfficeFoodService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\_ViewImports.cshtml"
using BackOfficeFoodService.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
using BackOfficeFoodService.Enum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcba1e6ce6ca6b3f604f2d26c5ab2aa9c1bb1568", @"/Views/Shared/ViewMensagem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2bb2ee245e2d1a76fd1b38cdb768655686e0836", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ViewMensagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
  
    string text = (string)TempData["FlashMessage.Text"];
    string cssClass = null;
    cssClass = (string)TempData["FlashMessage.Type"];

    if (!string.IsNullOrWhiteSpace(text))
    {
        cssClass = "success";
    }


    if (!string.IsNullOrWhiteSpace(text))
    {
        if (cssClass == "success")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert alert-success\" role=\"alert\">\r\n                ");
#nullable restore
#line 18 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
           Write(text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 20 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
        }
    }
    if (cssClass == "error")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger\" role=\"alert\">\r\n            ");
#nullable restore
#line 25 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
       Write(text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 27 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
    }
    if (cssClass == "warning")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning\" role=\"alert\">\r\n            ");
#nullable restore
#line 31 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
       Write(text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 33 "C:\Users\Tees\source\repos\FoodServiceApi\BackOfficeFoodService\Views\Shared\ViewMensagem.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
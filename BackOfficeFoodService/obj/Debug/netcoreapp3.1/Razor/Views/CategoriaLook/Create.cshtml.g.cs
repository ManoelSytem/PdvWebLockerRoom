#pragma checksum "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f76963aa64d8e0b9448daaa190bd107d1ca857b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CategoriaLook_Create), @"mvc.1.0.view", @"/Views/CategoriaLook/Create.cshtml")]
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
#line 1 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\_ViewImports.cshtml"
using BackOfficeFoodService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\_ViewImports.cshtml"
using BackOfficeFoodService.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f76963aa64d8e0b9448daaa190bd107d1ca857b9", @"/Views/CategoriaLook/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2bb2ee245e2d1a76fd1b38cdb768655686e0836", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_CategoriaLook_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BackOfficeFoodService.Models.CardapioModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
Write(await Html.PartialAsync("../Shared/ViewMensagem.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col\">\r\n            <h4>Nome Estoque</h4>\r\n            <hr />\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f76963aa64d8e0b9448daaa190bd107d1ca857b96523", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f76963aa64d8e0b9448daaa190bd107d1ca857b96797", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 15 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    <input type=\"hidden\" id=\"idCardapio\" name=\"custId\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f76963aa64d8e0b9448daaa190bd107d1ca857b98607", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 18 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.titulo);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f76963aa64d8e0b9448daaa190bd107d1ca857b910201", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 19 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.titulo);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f76963aa64d8e0b9448daaa190bd107d1ca857b911790", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 20 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.titulo);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""form-group"">
                    <input id=""Salvar"" type=""submit"" value=""Salvar"" class=""btn btn-primary"" />
                    <input id=""IdAtualizarCardapio"" style=""display:none;"" type=""button"" value=""Alterar"" onclick=""AtualizarCardapio()"" class=""btn btn-primary"" />
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""col"">
            <h4>Lista de estoque</h4>
            <hr />
            <table class=""table-striped table-bordered"">
                <thead>
                    <tr>
                        <th>
                            ");
#nullable restore
#line 35 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                       Write(Html.DisplayNameFor(model => model.titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>Estoque Principal</th>\r\n                        <th>Ações</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 42 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                     if (Model != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                         foreach (var item in Model.ListCardapio)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                       Write(Html.DisplayFor(modelItem => item.titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 51 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                             if (item.ePrincipal == "S")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div id=\"cadapioPrincipal\" class=\"col-md text-center custom-control custom-radio\">\r\n                                    <input class=\"form-check-input \" type=\"radio\" name=\"cardprincipal\"");
            BeginWriteAttribute("value", " value=\"", 2338, "\"", 2362, 1);
#nullable restore
#line 54 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 2346, item.idCardapio, 2346, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" checked>\r\n                                </div>\r\n");
#nullable restore
#line 56 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div id=\"cadapioNaoChecado\" class=\"col-md text-center custom-control custom-radio\">\r\n                                    <input class=\"form-check-input \" type=\"radio\" name=\"cardNaoChecado\"");
            BeginWriteAttribute("value", " value=\"", 2730, "\"", 2754, 1);
#nullable restore
#line 60 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 2738, item.idCardapio, 2738, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n");
#nullable restore
#line 62 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            <a href=\"#\" ;");
            BeginWriteAttribute("onclick", " onclick=\"", 2931, "\"", 2996, 6);
            WriteAttributeValue("", 2941, "CreateListCardapio(\'", 2941, 20, true);
#nullable restore
#line 65 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 2961, item.idCardapio, 2961, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2977, "\',", 2977, 2, true);
            WriteAttributeValue(" ", 2979, "\'", 2980, 2, true);
#nullable restore
#line 65 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 2981, item.titulo, 2981, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2993, "\');", 2993, 3, true);
            EndWriteAttribute();
            WriteLiteral(">Associar Categoria Look</a>\r\n                            |<a href=\"#\" ;");
            BeginWriteAttribute("onclick", " onclick=\"", 3069, "\"", 3114, 3);
            WriteAttributeValue("", 3079, "BuscarCardapio(\'", 3079, 16, true);
#nullable restore
#line 66 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 3095, item.idCardapio, 3095, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3111, "\');", 3111, 3, true);
            EndWriteAttribute();
            WriteLiteral(">Alterar</a>\r\n                            |<a href=\"#\" ;");
            BeginWriteAttribute("onclick", " onclick=\"", 3171, "\"", 3233, 6);
            WriteAttributeValue("", 3181, "ExcluirCardapio(\'", 3181, 17, true);
#nullable restore
#line 67 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 3198, item.idCardapio, 3198, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3214, "\',", 3214, 2, true);
            WriteAttributeValue(" ", 3216, "\'", 3217, 2, true);
#nullable restore
#line 67 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
WriteAttributeValue("", 3218, item.titulo, 3218, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3230, "\');", 3230, 3, true);
            EndWriteAttribute();
            WriteLiteral("> Excluir</a>\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 71 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"modal-body\" id=\"modal-body\"></div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f76963aa64d8e0b9448daaa190bd107d1ca857b921935", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 84 "E:\PdvWebLockerRoom\BackOfficeFoodService\Views\CategoriaLook\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BackOfficeFoodService.Models.CardapioModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

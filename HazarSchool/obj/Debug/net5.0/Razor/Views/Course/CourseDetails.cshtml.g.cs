#pragma checksum "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12fdcf9db37f5655ba2f6fdd45c4aa7afcf07c1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_CourseDetails), @"mvc.1.0.view", @"/Views/Course/CourseDetails.cshtml")]
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
#line 1 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\_ViewImports.cshtml"
using HazarSchool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\_ViewImports.cshtml"
using HazarSchool.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12fdcf9db37f5655ba2f6fdd45c4aa7afcf07c1f", @"/Views/Course/CourseDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83855ad05184287430c0d3f17fe37f13336bdf44", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Course_CourseDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HazarSchool.ViewModels.ResponseModels.CourseResponseViewModels.CourseResponseModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n\t<p>\r\n\t\tThe detail of the course is shown below;\r\n\t</p>\r\n\t<p>");
#nullable restore
#line 6 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"
  Write(Model.Data.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 7 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"
     foreach(var student in Model.Data.Students)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<p>");
#nullable restore
#line 9 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"
      Write(student.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t<p>");
#nullable restore
#line 10 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"
      Write(student.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t<p>");
#nullable restore
#line 11 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"
      Write(student.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t<p>");
#nullable restore
#line 12 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"
      Write(student.DepartmentName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 13 "C:\Users\Oluwafemi\Documents\HazarSchool\HazarSchool\Views\Course\CourseDetails.cshtml"

	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12fdcf9db37f5655ba2f6fdd45c4aa7afcf07c1f5285", async() => {
                WriteLiteral("Go back to index ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HazarSchool.ViewModels.ResponseModels.CourseResponseViewModels.CourseResponseModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

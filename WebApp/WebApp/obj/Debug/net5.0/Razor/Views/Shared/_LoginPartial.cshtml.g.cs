#pragma checksum "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3974f0d1495c71fea03c184d6055a0defd072bc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginPartial), @"mvc.1.0.view", @"/Views/Shared/_LoginPartial.cshtml")]
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
#line 1 "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3974f0d1495c71fea03c184d6055a0defd072bc1", @"/Views/Shared/_LoginPartial.cshtml")]
    public class Views_Shared__LoginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul class=\"navbar-nav\">\r\n");
#nullable restore
#line 6 "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml"
 if (SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"nav-item\">\r\n        <a  class=\"nav-link text-dark\" asp-area=\"Identity\" asp-page=\"/Account/Manage/Index\" title=\"Manage\">Hello ");
#nullable restore
#line 9 "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml"
                                                                                                            Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</a>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <form class=\"form-inline\" asp-area=\"Identity\" asp-page=\"/Account/Logout\"");
            BeginWriteAttribute("asp-route-returnUrl", " asp-route-returnUrl=\"", 488, "\"", 543, 1);
#nullable restore
#line 12 "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml"
WriteAttributeValue("", 510, Url.Page("/", new { area = "" }), 510, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" method=\"post\" >\r\n            <button  type=\"submit\" class=\"nav-link btn btn-link text-dark\">Logout</button>\r\n        </form>\r\n    </li>\r\n");
#nullable restore
#line 16 "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <li class=""nav-item"">
        <a class=""nav-link text-dark"" asp-area=""Identity"" asp-page=""/Account/Register"">Register</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link text-dark"" asp-area=""Identity"" asp-page=""/Account/Login"">Login</a>
    </li>
");
#nullable restore
#line 25 "C:\Users\usuario\Desktop\NetDev\WebApp\WebApp\Views\Shared\_LoginPartial.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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

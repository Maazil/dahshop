#pragma checksum "C:\Coding\dahshop\Dahshop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "81044d00ed59fbfaeb33a34b052d50dad74accc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Coding\dahshop\Dahshop\Views\_ViewImports.cshtml"
using Dahshop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Coding\dahshop\Dahshop\Views\_ViewImports.cshtml"
using Dahshop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81044d00ed59fbfaeb33a34b052d50dad74accc0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3cd41d5d16604e49fd5d62de8806011015f490c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Coding\dahshop\Dahshop\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    
    <h1 class=""display-4"">DahShop</h1>

    <br/>
    <br/>
    
    <!-----          Add a container to display ads        ----------->

    <div class=""col border border-dark"" style=""height: 100px"">
        <div class=""text-body center""> This is where the AD should be </div>
    </div>


    <br/>
    <br/>

    <div class=""row"">

        <div class=""col border border-primary"" style=""height: fit-content"">

            <div class=""row"">

                <!-----     The image clothes here   ------>
                <div class=""col border border-danger justify-content-center"">

                    <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                        <ol class=""carousel-indicators"">
                            <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                            <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
           ");
            WriteLiteral(@"                 <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
                        </ol>
                        <div class=""carousel-inner"">
                            <div class=""carousel-item active"">
                                <img src=""img_girl.jpg"" alt=""Girl in a jacket"" width=""250"" height=""300"">
                            </div>
                            <div class=""carousel-item"">
                                <img src=""img_chania.jpg"" alt=""Flowers in Chania"" width=""460"" height=""345"">
                            </div>
                            <div class=""carousel-item"">
                                <img src=""pic_trulli.jpg"" alt=""Trulli"" width=""500"" height=""333"">
                            </div>
                        </div>
                        <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"" style=""color: black"">
                            <span class=""carousel-control-prev-icon"" aria-h");
            WriteLiteral(@"idden=""true""></span>
                            <span class=""sr-only"">Previous</span>
                        </a>
                        <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"" style=""color: black"">
                            <span class=""carousel-control-next-icon"" aria-hidden=""true"" style=""color: black""></span>
                            <span class=""sr-only"">Next</span>
                        </a>
                    </div>

                </div>

                <!-----     Put name of the owner here, description and everything  ------>

                <div class=""col"">

                    <div class=""col border border-danger"">
                        Owner: Matthew Ling
                    </div>

                    <div class=""col border border-warning"">
                        Item: Jakke
                    </div>

                    <div class=""col border border-success"">
                        Farge: Brun");
            WriteLiteral(@"
                    </div>

                    <div class=""col border border-dark"">
                        Størrelse: L
                    </div>

                    <div class=""col border border-success"">
                        Status: Available
                    </div>

                    <div class=""col border border-success"">
                        Pris: 500 kr
                    </div>

                    <div class=""col border border-success"">
                        Beskrivelse: En veldig fin jakke som har blitt lite brukt og er så god som ny.
                    </div>

                </div>

            </div>

        </div>
        
        <script src=""js/googleUserInfo.js""></script>


        <!---------------  
        
        <div class=""w-100""></div> <br/>
        <div class=""col border border-danger"">col</div>
        
        ---------------->
        
        
    </div>     <!---------------  Div class row  ---------------->


    

</d");
            WriteLiteral("iv>     <!---------------  Div first container  ---------------->\r\n\r\n");
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

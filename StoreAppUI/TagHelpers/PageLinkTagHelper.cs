using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreAppUI.Models;
using System.Runtime.CompilerServices;

namespace StoreAppUI.TagHelpers
{
	[HtmlTargetElement("div", Attributes = "page-model")]
	public class PageLinkTagHelper : TagHelper
	{
		private readonly IUrlHelperFactory _urlHelperFactory;

		//ViewContext sınıfı, bir view calistirildiginda o view'e ait olan baglami temsil eder; ViewContext icerisinde HttpContext, ViewData, TempData, Model, RouteData gibi pek cok bilgi icerisinde barinir
		//bu bilgileri isleyeceksek, bu bilgiler uzerinden orn link ureteceksek bu attribute(ViewContext)'u kullanabiliriz. Kısacasi Gorunum(View)'e ait baglamlari temsil eden bir yapidir.
		[ViewContext]
		[HtmlAttributeNotBound] //html sayfasiyla bu ifadenin eslesmesini engelleyelim?
		public ViewContext? ViewContext { get; set; } //ViewContext sinifi bir gorunum calistirildiginda o gorunume iliskin baglami temsil eder 
		public Pagination PageModel { get; set; }
		public string? PageAction { get; set; }
		public bool PageClassesEnabled { get; set; } = false;
		public string PageClass { get; set; } = string.Empty;
		public string PageClassNormal { get; set; } = string.Empty;
		public string PageClassSelected { get; set; } = string.Empty;
		public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
		{
			_urlHelperFactory = urlHelperFactory;
		}
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			if (ViewContext != null && PageModel != null)
			{
				IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
				TagBuilder div = new TagBuilder("div");
				for (int i = 1; i <= PageModel.TotalPages; i++)
				{
					TagBuilder a = new TagBuilder("a");
					a.Attributes.Add("href", urlHelper.Action(PageAction, new { PageNumber = i }));
					//a.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i }); usttekiyle aynisi
					if (PageClassesEnabled)
					{
						a.AddCssClass(PageClass);
						a.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
					}
					a.InnerHtml.Append(i.ToString());
					div.InnerHtml.AppendHtml(a);
				}
				output.Content.AppendHtml(div.InnerHtml);
			}
		}
	}
}

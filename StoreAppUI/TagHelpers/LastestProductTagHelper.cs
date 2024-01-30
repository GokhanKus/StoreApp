using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Business.AbstractServices;

namespace StoreAppUI.TagHelpers
{
	[HtmlTargetElement("div", Attributes = "products")]
	public class LastestProductTagHelper : TagHelper
	{
		private readonly IServiceManager _manager;

		public LastestProductTagHelper(IServiceManager manager)
		{
			_manager = manager;
		}

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			//_Footer.cshtml'e bak
			TagBuilder div = new TagBuilder("div"); //bu satirlar <div class="my-3"></div>' a karsilik gelmektedir.
			div.Attributes.Add("class", "my-3");

			TagBuilder h6 = new TagBuilder("h6");
			h6.Attributes.Add("class", "lead");

			TagBuilder icon = new TagBuilder("i");
			icon.Attributes.Add("class", "fa fa-box text-secondary");

			h6.InnerHtml.AppendHtml(icon); //<i> etiketi ve Lastest Products ifadesi h6'nin icinde oldugu icin bu sekilde ifade edilmeli.
			h6.InnerHtml.AppendHtml("Lastest Products");

			div.InnerHtml.AppendHtml(h6); //ayni sekilde h6 da divin icerisinde barinmaktadir.

			TagBuilder ul = new TagBuilder("ul");

			var products = _manager.ProductService.GetLastestProducts(5, false);
			foreach (var prd in products)
			{
				TagBuilder li = new TagBuilder("li");

				TagBuilder a = new TagBuilder("a");
				a.Attributes.Add("href", $"Product/Get/{prd.Id}");
				a.InnerHtml.AppendHtml(prd.ProductName);

				li.InnerHtml.AppendHtml(a);
				ul.InnerHtml.AppendHtml(li);
			}

			div.InnerHtml.AppendHtml(ul);

			output.Content.AppendHtml(div);
		}
	}
}

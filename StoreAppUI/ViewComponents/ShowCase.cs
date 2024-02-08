using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;

namespace StoreAppUI.ViewComponents
{
	public class ShowCase : ViewComponent
	{
		private readonly IServiceManager _manager;

		public ShowCase(IServiceManager services)
		{
			_manager = services;
		}
		public IViewComponentResult Invoke(string page = "default")
		{
			var products = _manager.ProductService.GetShowCaseProducts(false);
			return page.Equals("default")
				? View(products)
				: View("List", products);
		}
	}
}

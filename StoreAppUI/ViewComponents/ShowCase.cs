using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;

namespace StoreAppUI.ViewComponents
{
	public class ShowCase:ViewComponent
	{
		private readonly IServiceManager _manager;

		public ShowCase(IServiceManager services)
		{
			_manager = services;
		}
		public IViewComponentResult Invoke()
		{
			var products = _manager.ProductService.GetShowCaseProducts(false);
			return View(products);
		}
	}
}

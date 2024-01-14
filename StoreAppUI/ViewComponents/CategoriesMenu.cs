using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;

namespace StoreAppUI.ViewComponents
{
	public class CategoriesMenu:ViewComponent
	{
		private readonly IServiceManager _manager;

		public CategoriesMenu(IServiceManager manager)
		{
			_manager = manager;
		}
		public IViewComponentResult Invoke()//geriye bir view nesnesi dönmesini istedigimiz icin IViewComponentResult kullandik
		{
			var categories = _manager.CategoryService.GetAllCategories(false);
			return View(categories);
		}
	}
}

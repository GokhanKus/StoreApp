using Microsoft.AspNetCore.Mvc;

namespace StoreAppUI.ViewComponents
{
	public class ProductFilterMenu : ViewComponent
	{
		//Coding by Convention
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

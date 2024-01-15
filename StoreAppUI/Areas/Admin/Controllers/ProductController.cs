using Microsoft.AspNetCore.Mvc;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulunması gerektigi anlamına gelir
	//Aynı controller isminden oldugu icin Area attribute'sini eklemek zorundayız.
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

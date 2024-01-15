using Microsoft.AspNetCore.Mvc;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulunması gerektigi anlamına gelir?
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

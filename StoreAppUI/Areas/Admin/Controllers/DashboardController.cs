using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulunması gerektigi anlamına gelir?
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			TempData["info"] = $"Welcome back, { DateTime.Now.ToShortTimeString() }";
			return View();
		}
	}
}

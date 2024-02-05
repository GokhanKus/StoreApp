using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Authorize(Roles ="Admin")]
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulunması gerektigi anlamına gelir
	//yani eger yazmazsak ve aynı controller isminden birden fazla varsa hata verir.
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

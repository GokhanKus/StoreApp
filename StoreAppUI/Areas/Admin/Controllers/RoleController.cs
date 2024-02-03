using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RoleController : Controller
	{
		private readonly IServiceManager _manager;

		public RoleController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var roles = _manager.AuthService.Roles;
			return View(roles);
		}
	}
}

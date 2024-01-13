using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.Model.Entities;

namespace StoreAppUI.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IRepositoryManager _manager;
		public CategoryController(IRepositoryManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var model = _manager.Category.FindAll(false);
			return View(model);
		}
	}
}

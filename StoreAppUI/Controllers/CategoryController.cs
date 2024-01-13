using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.Model.Entities;

namespace StoreAppUI.Controllers
{
	public class CategoryController : Controller
	{
		//private readonly IRepositoryManager _manager;
		private readonly IServiceManager _manager;
		public CategoryController(IServiceManager services)
		{
			_manager = services;
		}

		public IActionResult Index()
		{
			var model = _manager.CategoryService.GetAllCategories(false);
			return View(model);
		}
	}
}

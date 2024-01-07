using Microsoft.AspNetCore.Mvc;
using StoreApp.DataAccess.Context;
using System.Runtime.CompilerServices;

namespace StoreAppUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly StoreContext _context;

		public ProductController(StoreContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var model = _context.Products.ToList();
			return View(model);
		}
		public IActionResult Get(int? id)
		{
			var model = _context.Products.FirstOrDefault(p => p.Id.Equals(id));//(p=>p.Id == id);
			return View(model);
		}
	}
}

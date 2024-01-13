using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.AbstractRepos;
using System.Diagnostics;

namespace StoreAppUI.Controllers
{
	public class ProductController : Controller
	{
		//private readonly StoreContext _context;
		//private readonly IRepositoryManager _manager;
		private readonly IServiceManager _manager;

		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}
		public IActionResult Index()
		{
			var model = _manager.ProductService.GetAllProducts(false);
			return View(model);
		}
		public IActionResult Get([FromRoute(Name = "id")]int id) //FromRoute gibi attributelar, HTTP isteklerinden gelen verilerin doğru parametrelere bağlanmasını sağlamak için kullanılır.
		{
			var model = _manager.ProductService.GetOneProduct(id, false);
			return View(model);
		}
	}
}

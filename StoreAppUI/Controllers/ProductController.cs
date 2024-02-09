using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.Model.RequestParameters;
using StoreAppUI.Models;
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
		public IActionResult Index(ProductRequestParameters p)
		{
			var products = _manager.ProductService.GetAllProductsWithDetails(p);
			if (p.IsValidPrice == false)
			{
				ModelState.AddModelError("", "Min Price must be smaller than Max Price");
			}
			var pagination = new Pagination
			{
				ItemsPerPage = p.PageSize,
				CurrentPage = p.PageNumber,
				TotalItems = _manager.ProductService.GetAllProducts(false).Count()
			};
			return View(new ProductListViewModel
			{
				Pagination = pagination,
				Products = products
			});
		}
		public IActionResult Get([FromRoute(Name = "id")] int id) //FromRoute gibi attributelar, HTTP isteklerinden gelen verilerin doğru parametrelere bağlanmasını sağlamak için kullanılır.
		{
			var model = _manager.ProductService.GetOneProduct(id, false);
			ViewData["title"] = $"{model?.ProductName}";
			return View(model);
		}
	}
}


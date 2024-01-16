using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.Entities;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulunması gerektigi anlamına gelir
				   //Aynı controller isminden oldugu icin Area attribute'sini eklemek zorundayız.
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;

		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index()
		{
			var products = _manager.ProductService.GetAllProducts(false);
			return View(products);
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([FromForm] Product product) //productın formdan geldigini söylüyoruz.
		{
			_manager.ProductService.CreateProduct(product);
			return RedirectToAction("Index");
		}
	}
}

/*[ValidateAntiForgeryToken] özniteliği, ASP.NET Core uygulamalarında güvenlik amacıyla kullanılan bir özelliktir. 
Bu öznitelik, bir form gönderildiğinde sunucu tarafında, bu formun belirli bir sayfadan mı yoksa uygulamanın içindeki başka bir kaynaktan mı geldiğini 
doğrulamak için kullanılır. Bu, Cross-Site Request Forgery (CSRF) saldırılarına karşı bir önlem sağlar.
*/
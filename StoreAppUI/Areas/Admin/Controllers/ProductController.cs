using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.Context;
using StoreApp.Model.DTOs;
using StoreApp.Model.Entities;
using StoreApp.Model.RequestParameters;
using StoreAppUI.Models;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]//bu attributeyi yazarak bu controllerin Areas/Admin icerisinde bulunması gerektigi anlamına gelir
				   //Aynı controller isminden oldugu icin Area attribute'sini eklemek zorundayız.
	public class ProductController : Controller
	{
		private readonly IServiceManager _manager;
		public ProductController(IServiceManager manager)
		{
			_manager = manager;
		}

		public IActionResult Index([FromQuery]ProductRequestParameters p)
		{
			//var products = _manager.ProductService.GetAllProducts(false);
			//bu metottaki kodları bir service tarafında yazsaydik, hem burada hem de user altindaki product index te aynisini yazmazdik (kod tekrari)
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
		public IActionResult Create()
		{
			ViewBag.Categories = GetCategories();

			//secilebilir bir liste tanımı olusturduk ve dbdeki kayitlari item olarak belirledik
			//Id veri alani, CategoryName text alani ve id'si 1 olan default olarak secili gelsin ve artik cshtmlde foreach gerek yok
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile? file) //productın formdan geldigini söylüyoruz.
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);
					#region using aciklama
					//using ifadesini, kaynak gerektiren maliyeti yuksek olan operasyonları yuruturken kullanırız.
					//using ifadesi: using ifadesi, IDisposable arabirimine sahip nesnelerin kullanıldıktan sonra temizlenmesi için kullanılır.
					//Bu ifade ile belirtilen nesneler kod bloğundan çıktıktan sonra(usingden cikinca) otomatik olarak kapatılır ve kaynaklar serbest bırakılır.
					#endregion
					using (var stream = new FileStream(path, FileMode.Create))//file varsa uzerine yazacak
					{
						await file.CopyToAsync(stream);
					}
					//productDto.ImageUrl = string.Concat("/img/", file.FileName);
					productDto.ImageUrl = file.FileName; //imageurl = "1.jpg", "2.jpg" vs. oldugu icin concata gerek yok.
				}

				else productDto.ImageUrl = "product.png"; //resim eklemek zorunlu olmasın ya da client sonradan ekleyebilsin ama eklemezse default olarak bir resim gelsin

				_manager.ProductService.CreateProduct(productDto);
				TempData["success"] = $"{productDto.ProductName} has been created.";
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult Update(int id)
		{
			ViewBag.Categories = GetCategories();
			var product = _manager.ProductService.GetOneProductForUpdate(id, false);
			return View(product);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile? file) //create asamasında resim eklenmezse bile default resim atadık o yüzden nullable olmasına gerek yok.
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName);
					#region using aciklama
					//using ifadesini, kaynak gerektiren maliyeti yuksek olan operasyonları yuruturken kullanırız.
					//using ifadesi: using ifadesi, IDisposable arabirimine sahip nesnelerin kullanıldıktan sonra temizlenmesi için kullanılır.
					//Bu ifade ile belirtilen nesneler kod bloğundan çıktıktan sonra(usingden cikinca) otomatik olarak kapatılır ve kaynaklar serbest bırakılır.
					#endregion
					using (var stream = new FileStream(path, FileMode.Create))//file varsa uzerine yazacak
					{
						await file.CopyToAsync(stream);
					}
					//productDto.ImageUrl = string.Concat("/img/", file.FileName);
					productDto.ImageUrl = file.FileName; //imageurl = "1.jpg", "2.jpg" vs. oldugu icin concata gerek yok.
				}

				//else productDto.ImageUrl = "product.png"; default one 
				//else productDto.ImageUrl = ImageUrl;

				_manager.ProductService.UpdateOneProduct(productDto);
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Delete([FromRoute(Name = "id")] int id)
		{
			_manager.ProductService.DeleteOneProduct(id);
			TempData["danger"] = $"The product has been removed";
			return RedirectToAction("Index");
		}
		private SelectList GetCategories()
		{
			return new SelectList(_manager.CategoryService.GetAllCategories(false), "Id", "CategoryName", "1");
		}
	}
}

/*[ValidateAntiForgeryToken] özniteliği, ASP.NET Core uygulamalarında güvenlik amacıyla kullanılan bir özelliktir. 
Bu öznitelik, bir form gönderildiğinde sunucu tarafında, bu formun belirli bir sayfadan mı yoksa uygulamanın içindeki başka bir kaynaktan mı geldiğini 
doğrulamak için kullanılır. Bu, Cross-Site Request Forgery (CSRF) saldırılarına karşı bir önlem sağlar.
*/
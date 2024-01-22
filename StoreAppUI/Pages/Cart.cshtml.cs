using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.Entities;

namespace StoreAppUI.Pages
{
	public class CartModel : PageModel
	{
		private readonly IServiceManager _manager;
		public Cart Cart { get; set; } //IoC
		public CartModel(IServiceManager manager, Cart cart)
		{
			_manager = manager;
			Cart = cart; //singleton nesnesi, inject islemi
		}
		public string ReturnUrl { get; set; } = "/"; //user'�n bu sayfaya hangi sayfadan eristiginin bilgisini tutal�m.
		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl ?? "/"; //parametre olarak gelen url bos ise bizi "/" dizinine (k�k) gotursun
		}
		public IActionResult OnPost(int Id, string returnUrl)//sepete eklenecek urunler icin bir action
		{
			Product? product = _manager.ProductService.GetOneProduct(Id, false);//update yapmadigimiz icin trackchanges false olabilir.
			if (product is not null)
			{
				Cart.AddItem(product, 1);
			}
			return Page();//returnUrl
		}
		public IActionResult OnPostRemove(int Id, string returnUrl)
		{
			Cart.RemoveLine(Cart.CartLines.First(i => i.Product.Id.Equals(Id)).Product);
			return Page();
		}
	}
}

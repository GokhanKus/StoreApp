using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.Entities;
using StoreAppUI.ExtensionMethods;

namespace StoreAppUI.Pages
{
	public class CartModel : PageModel
	{
		private readonly IServiceManager _manager;
		public Cart Cart { get; set; } //IoC
		public CartModel(IServiceManager manager, Cart cartService)//cartService ekleyerek kod tekrarindan kurtulduk.(asagidaki metotlarda ayni satirlar var(SessionCart.cs bak))
		{
			_manager = manager;
			Cart = cartService;
		}
		public string ReturnUrl { get; set; } = "/"; //user'�n bu sayfaya hangi sayfadan eristiginin bilgisini tutal�m.
		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl ?? "/"; //parametre olarak gelen url bos ise bizi "/" dizinine (k�k) gotursun
			//Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); (gerek kalmayan satir)
			//inject islemi olarak bu sekilde yapiyoruz artik scoped tanimlamamiza ragmen(IoC) veriler kaybolmayacak.
			//cunku sessiondan nesne al�p okuyup tekrar sessiona ilgili veriyi gonderecek sekilde bir yap� kurduk.
		}
		public IActionResult OnPost(int Id, string returnUrl)//sepete eklenecek urunler icin bir action
		{
			Product? product = _manager.ProductService.GetOneProduct(Id, false);//update yapmadigimiz icin trackchanges false olabilir.
			if (product is not null)
			{
				//cart nesnesini sessiondan okuyoruz eger yoksa olusturuyoruz ve GetJson() nesneyi deserialize etti ve bize bir class verdi
				//Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); (gerek kalmayan satir.)
				Cart.AddItem(product, 1); //ve o class uzerinden yeni nesneyi ekliyoruz. ve artik cart nesnemiz degisti. sessionda farkl� classta farkl� bilgiler var
				//HttpContext.Session.SetJson<Cart>("cart", Cart); //veriyi session'a yazm�s oluyoruz. boylelikle yeni urun eklerken onceki kaybolmayacak (gerek kalmayan satir)
				//HttpContext.Session.SetJson("cart", Cart);
			}
			return RedirectToPage(new {returnUrl = returnUrl});//user sepete urun ekledikten sonra alisverise devam et butonuna basinca bir onceki sayfaya yonlendirilsin(ExtensionMethods/HttpRequestExtension.cs bak)
		}
		public IActionResult OnPostRemove(int Id, string returnUrl)
		{
			//Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); (gerek kalmayan satir)
			Cart.RemoveLine(Cart.CartLines.First(i => i.Product.Id.Equals(Id)).Product);
			//HttpContext.Session.SetJson<Cart>("cart", Cart); (gerek kalmayan satir)

			return Page();
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.Entities;

namespace StoreAppUI.Pages
{
	public class CardModel : PageModel
	{
		private readonly IServiceManager _manager;
		public CardModel(IServiceManager manager)
		{
			_manager = manager;
		}
		public Card Card { get; set; } //IoC
		public string ReturnUrl { get; set; } = "/"; //user'ýn bu sayfaya hangi sayfadan eristiginin bilgisini tutalým.
		public void OnGet(string returnUrl)
		{
			ReturnUrl = returnUrl ?? "/"; //parametre olarak gelen url bos ise bizi "/" dizinine (kök) gotursun
		}
		public IActionResult OnPost(int Id, string returnUrl)//sepete eklenecek urunler icin bir action
		{
			Product? product = _manager.ProductService.GetOneProduct(Id, false);//update yapmadigimiz icin trackchanges false olabilir.
			if (product is not null)
			{
				Card.AddItem(product, 1);
			}
			return Page();//returnUrl
		}
		public IActionResult OnPostRemove(int Id, string returnUrl)
		{
			Card.RemoveLine(Card.CardLines.First(i => i.Product.Id.Equals(Id)).Product);
			return Page();
		}
	}
}

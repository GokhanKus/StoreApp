using Microsoft.AspNetCore.Mvc;
using StoreApp.Model.Entities;

namespace StoreAppUI.ViewComponents
{
	public class CartSummary:ViewComponent
	{
		private readonly Cart _cart;
        public CartSummary(Cart cartService)
        {
            _cart = cartService;
        }
        public string Invoke()
        {
            return _cart.CartLines.Count.ToString();
        }
    }
}

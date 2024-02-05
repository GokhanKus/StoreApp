using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.Entities;

namespace StoreAppUI.Controllers
{
	public class OrderController : Controller
	{
		private readonly IServiceManager _manager;
		private readonly Cart _cart;
		public OrderController(IServiceManager manager, Cart cart)
		{
			_manager = manager;
			_cart = cart;
		}
		[Authorize]//user sepete urun ekledikten sonra islemin devami icin login olması gerekir
		public ViewResult CheckOut()
		{
			return View(new Order());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CheckOut([FromForm] Order order)
		{
			if (_cart.CartLines.Count() == 0)
			{
				ModelState.AddModelError("", "Sorry your cart is empty");
			}
			if (ModelState.IsValid)
			{
				order.Lines = _cart.CartLines.ToArray();
				_manager.OrderService.SaveOrder(order);
				_cart.Clear();
				return RedirectToPage("/Complete",new {Id = order.Id});//.. numarali siparisiniz alinmistir tesekkur ederiz sayfasina gider.
			}
			return View();
		}
	}
}

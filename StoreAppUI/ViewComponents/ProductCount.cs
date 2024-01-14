using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.Context;

namespace StoreAppUI.ViewComponents
{
	public class ProductCount : ViewComponent
	{
		//private readonly StoreContext _context; //Dogrudan contexti injectlemek dogru degil cunku örnegin butun urunler aktif olmayabilir
		//ya da bazı urunler tukenmistir, satisi aktif olmayabilir bu yüzden bu gibi durumlarda o urunleri gostermek istemeyiz ve bu filtreleme islemlerini
		//servis katmanlarında yapariz, dolayisiyla service manageri enjekte edebiliriz onu bu yüzden yazdık.
		private readonly IServiceManager _manager;
		public ProductCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.ProductService.GetAllProducts(false).Count().ToString();
		}
	}
}
/*
ViewComponentler PartialViewlerden farklı olarak, üzerinde calisabileceğimiz, mantik isletebilecegimiz bir fonksiyon verir ve bu fonk yardımıyla
backendde istedigimiz alana erisebilip async olarak cagirabildigimiz icin sayfanın genel calısma mantigindan bagimsiz bir sekilde render edilmesini,
yani html'e cevrilmesini saglayabiliriz 

ViewComponentler HttpContext, Request, User, RouteData, ViewBag, ModelState, ViewData gibi nesnelerle çalısmamiza olanak tanir.
*/
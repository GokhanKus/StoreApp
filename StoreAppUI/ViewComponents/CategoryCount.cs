using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.Context;

namespace StoreAppUI.ViewComponents
{
	public class CategoryCount : ViewComponent
	{
		private readonly IServiceManager _manager;
		public CategoryCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.CategoryService.GetAllCategories(false).Count().ToString();
		}
	}
}
/*
ViewComponentler PartialViewlerden farklı olarak, üzerinde calisabileceğimiz, mantik isletebilecegimiz bir fonksiyon verir ve bu fonk yardımıyla
backendde istedigimiz alana erisebilip async olarak cagirabildigimiz icin sayfanın genel calısma mantigindan bagimsiz bir sekilde render edilmesini,
yani html'e cevrilmesini saglayabiliriz 

ViewComponentler HttpContext, Request, User, RouteData, ViewBag, ModelState, ViewData gibi nesnelerle çalısmamiza olanak tanir.
*/
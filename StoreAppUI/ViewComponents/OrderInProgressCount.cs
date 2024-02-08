using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.Context;

namespace StoreAppUI.ViewComponents
{
	public class OrderInProgressCount : ViewComponent
	{
		private readonly IServiceManager _manager;
		public OrderInProgressCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.OrderService.NumberOfInProcess.ToString();
		}
	}
}

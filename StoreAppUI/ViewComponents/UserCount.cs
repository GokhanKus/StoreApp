using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.DataAccess.Context;

namespace StoreAppUI.ViewComponents
{
	public class UserCount : ViewComponent
	{
		private readonly IServiceManager _manager;
		public UserCount(IServiceManager manager)
		{
			_manager = manager;
		}
		public string Invoke()
		{
			return _manager.AuthService.GetAllUsers().Count().ToString();
		}
	}
}

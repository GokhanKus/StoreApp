using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.DTOs;
using System.Net.WebSockets;

namespace StoreAppUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IServiceManager _manager;

		public UserController(IServiceManager manager)
		{
			_manager = manager;
		}
		public IActionResult Index()
		{
			var users = _manager.AuthService.GetAllUsers();
			return View(users);
		}
		public IActionResult Create()
		{
			//userModel.Roles = new HashSet<string>(_manager.AuthService.Roles.Select(r => r.Name).ToList());
			//return View(userModel);
			return View(new UserDtoForCreation
			{
				Roles = new HashSet<string>(_manager.AuthService.Roles.Select(r => r.Name).ToList())
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
		{
			//TODO: AuthService'de throw new Exception yerine daha farklı yaklasim izlenebilir hata yonetimi icin (asagidaki modelstate errorlara girmeden hata alıyoruzt)
			var result = await _manager.AuthService.CreateUserAsync(userDto);

			if (!result.Succeeded)
			{
				foreach (IdentityError err in result.Errors)
				{
					ModelState.AddModelError("", "while creating the user, an error occured");
				}
				return View();
			}
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Update(string username)//[FromRoute(Name = "username")] bunu yazınca hata veriyor ya da bunu yazarsak: [FromRoute(Name = "id")] string id seklinde yazmalıyız 
		{
			var user = await _manager.AuthService.GetOneUserForUpdateAsync(username);
			return View(user);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto)
		{
			if (ModelState.IsValid)
			{
				await _manager.AuthService.UpdateUserAsync(userDto);
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> ResetPassword(string username)
		{
			var model = new ResetPasswordDto { UserName = username };
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto model)
		{
			if (ModelState.IsValid)
			{
				var user = await _manager.AuthService.ResetPasswordAsync(model);
				if (!user.Succeeded)
				{
					foreach (IdentityError err in user.Errors)
					{
						ModelState.AddModelError("", "While processing reset the password, an error occured");
					}
					return View();
				}
				return RedirectToAction("Index", "User");
			}
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteUser([FromForm]string username)//[FromForm]
		{
			var result = await _manager.AuthService.DeleteUserAsync(username);
			return result.Succeeded ?
				RedirectToAction("Index")
				: View();
		}
	}
}

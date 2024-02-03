﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Business.AbstractServices;
using StoreApp.Model.DTOs;

namespace StoreAppUI.Areas.Admin.Controllers
{
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
	}
}
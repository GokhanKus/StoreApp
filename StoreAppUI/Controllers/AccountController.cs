using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using StoreApp.Model.DTOs;
using StoreAppUI.IdentityModels;

namespace StoreAppUI.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
		{
			return View(new LoginModel
			{
				ReturnUrl = ReturnUrl,
			});
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([FromForm] LoginModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityUser? user = await _userManager.FindByNameAsync(model.UserName);
				if (user != null)
				{
					await _signInManager.SignOutAsync(); //oturum acmis user var ise once oturumdan cikis islemini gerceklestirmeliyiz?
					var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false); //giris yapma islemi
					if (result.Succeeded)
					{
						return Redirect(model.ReturnUrl); //bizi "/"'ye yonlendirsin (homepage)
					}
				}
				ModelState.AddModelError("Error", "Invalid Username or Password");
			}
			return View();
		}
		public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/") //?ReturnUrl, account/logout/?ReturnUrl=/product url'e bunu yazarsak logout olup product sayfasina bizi gonderir
		{
			await _signInManager.SignOutAsync();
			return Redirect(ReturnUrl);
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([FromForm] RegisterDto model)
		{
			if (ModelState.IsValid)
			{
				var user = new IdentityUser
				{
					UserName = model.UserName,
					Email = model.Email
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(user, "User");
					if (roleResult.Succeeded)
						return RedirectToAction("Login");
				}
				else
				{
					foreach (IdentityError err in result.Errors) //ilgili hata mesajlarını yazdıralım eğer valid değilse
					{
						ModelState.AddModelError("", err.Description);
					}
				}
			}
			return View();
		}
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StoreApp.DataAccess.Context;

namespace StoreAppUI.ExtensionMethods
{
	public static class ApplicationExtension
	{
		public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
		{
			StoreContext context = app
				.ApplicationServices    //app'in servisine erisim saglayip,
				.CreateScope()          //kendimize bir scope olusturup,
				.ServiceProvider        //bu scope dahilinde bir service providera odaklanıp,
				.GetRequiredService<StoreContext>(); //bana gerekli olan StoreContext alalım
													 //yani kisacasi ihtiyac duydugum servisin bana uygulama uzerinden temin edilmesini sagladim (newlemeden)

			if (context.Database.GetPendingMigrations().Any()) //askida olan any migration varsa (uygulanmayan)
			{
				context.Database.Migrate(); //update-database
			}
		}
		public static void ConfigureLocalization(this WebApplication app) //this IApplicationBuilder app da yazilabilir daha iyi olur.
		{
			//bolgeden bolgeye lokalizasyon(yerellestirme) islemidir. ornegin tr icin para sembolu olarak "₺" gozukecektir cunku yerellestirdik, desteklenen kultur olarak tr ekledik.
			app.UseRequestLocalization(options =>
			{
				options.AddSupportedCultures("tr-TR")
					.AddSupportedUICultures("tr-TR")
					.SetDefaultCulture("tr-TR");
			});

			#region Farklı kultur de ekleyebiliriz
			//app.UseRequestLocalization(options =>
			//{
			//	options.AddSupportedCultures("tr-TR", "de-DE", "en-US","en-GB") tr de us uk
			//		   .AddSupportedUICultures("tr-TR", "de-DE", "en-US","en-GB")
			//		   .SetDefaultCulture("tr-TR");
			//});
			#endregion
		}
		public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
		{
			const string adminUser = "Admin";
			const string adminPassword = "Admin123456";

			UserManager<IdentityUser> userManager = app //UserManager userlar ile calismak icin metotlar saglar (ConfigureAndCheckMigration) metodundaki gibi yazdik.
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();
			
			RoleManager<IdentityRole> roleManager = app
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole>>();

			IdentityUser? user = await userManager.FindByNameAsync(adminUser); //"Admin" adinda bir user var mi? yoksa olusturalim. 
			if (user == null)
			{
				user = new IdentityUser()
				{
					Email = "gkus1998@gmail.com",
					PhoneNumber = "5055555555",
					UserName = adminUser
				};

				IdentityResult userResult = await userManager.CreateAsync(user, adminPassword);

				if (!userResult.Succeeded)
					throw new Exception("Admin user could not created"); //eger useri olustururken hata alirsak programı keselim hata fırlatalim

				IdentityResult roleResult = await userManager.AddToRolesAsync(user, //admin olacak user'a butun rolleri verelim.
					 roleManager
					.Roles
					.Select(r => r.Name)
					.ToList()			
					);

				if (!roleResult.Succeeded)
					throw new Exception("System hava problems with role defination for admin");
			}
		}
	}
}

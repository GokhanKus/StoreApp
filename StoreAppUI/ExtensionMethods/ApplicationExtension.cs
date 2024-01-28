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
		public static void ConfigureLocalization(this WebApplication app)
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
	}
}

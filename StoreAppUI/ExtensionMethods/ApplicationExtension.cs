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
				.ApplicationServices	//app'in servisine erisim saglayip,
				.CreateScope()			//kendimize bir scope olusturup,
				.ServiceProvider		//bu scope dahilinde bir service providera odaklanıp,
				.GetRequiredService<StoreContext>(); //bana gerekli olan StoreContext alalım
			//yani kisacasi ihtiyac duydugum servisin bana uygulama uzerinden temin edilmesini sagladim (newlemeden)

			if (context.Database.GetPendingMigrations().Any()) //askida olan any migration varsa (uygulanmayan)
			{
				context.Database.Migrate(); //update-database
			}
		}
	}
}

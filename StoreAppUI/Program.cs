using StoreApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace StoreAppUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region DatabaseConnection
			var connectionString = builder.Configuration.GetConnectionString("sqLiteConnection");
			builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionString));
			//MigrationAssembly("StoreAppUI") bu ifade migration klasorunun storeappUI da olusturur, aksi taktirde dataaccesste olusturur.
			#endregion

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}

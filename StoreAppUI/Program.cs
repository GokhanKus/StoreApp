using StoreApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.ConcreteRepos;

namespace StoreAppUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region DatabaseConnection
			var connectionString = builder.Configuration.GetConnectionString("sqLiteConnection");
			builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionString,b=>b.MigrationsAssembly("StoreAppUI")));
			//MigrationAssembly("StoreApp.Model") bu ifade migration klasorunun StoreApp.Model da olusturur, aksi taktirde dataaccesste olusturur.
			#endregion

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			#region Injections

			builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
			builder.Services.AddScoped<IProductRepository,ProductRepository>();

			#endregion

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

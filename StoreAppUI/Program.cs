using StoreApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.ConcreteRepos;
using StoreApp.Business.AbstractServices;
using StoreApp.Business.ConcreteServices;
using Microsoft.AspNetCore.Builder;
using AutoMapper;
using StoreApp.Business.Mapper;

namespace StoreAppUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			#region DatabaseConnection
			var connectionString = builder.Configuration.GetConnectionString("sqLiteConnection");
			builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("StoreAppUI")));
			//MigrationAssembly("StoreApp.Model") bu ifade migration klasorunun StoreApp.Model da olusturur, aksi taktirde dataaccesste olusturur.
			#endregion

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();//artik controllerlar olmadan razor pageleri kullanabiliriz.
			#region Injections

			builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

			builder.Services.AddScoped<IServiceManager, ServiceManager>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();

			#endregion

			//builder.Services.AddAutoMapper(typeof(Program));//automapper eklendi
			builder.Services.AddAutoMapper(typeof(MappingProfile)); // MappingProfile'ý ekleyin

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
				);
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages(); //routing mekanizmasýnda bir problem yasamamamak icin ve endpointlerin uyusmasi icin bu satiri yazdýk.
			});
			//Area'lar kucuk mvc projeleri olarak dusunulebilir.

			//app.MapAreaControllerRoute(
			//	name: "Admin",
			//	areaName: "Admin",
			//	pattern: "Admin/{controller=DashBoard}/{action=Index}/{id?}");

			//app.MapControllerRoute(
			//	name: "default",
			//	pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}

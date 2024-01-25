using StoreApp.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.ConcreteRepos;
using StoreApp.Business.AbstractServices;
using StoreApp.Business.ConcreteServices;
using Microsoft.AspNetCore.Builder;
using AutoMapper;
using StoreApp.Business.Mapper;
using StoreApp.Model.Entities;
using StoreAppUI.Models;

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

			builder.Services.AddDistributedMemoryCache();//onbellek ekler, session icin user bilgilerini ram'de saklamak ve paylasmak icin tercih edilebilir
														 //Oturum yönetimi, kullanýcýlarýn uygulama içindeki etkileþimleri sýrasýnda belirli bilgileri tutma ve paylaþma mekanizmasýdýr.
			builder.Services.AddSession(options =>
			{
				options.Cookie.Name = "StoreApp.Session";
				options.IdleTimeout = TimeSpan.FromMinutes(10);//userdan 10 dk icerisinden fresh bir request gelmezse oturumu sonlandir.
			});
			//builder.Services.AddHttpContextAccessor();
			builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			#region HttpContextAccessor
			/*
			 * HttpContext nesnesine erisim saglar, bu nesne bir http requestin icerisinde barindirabilecegi cesitli bilgileri ve durumu temsil eder; 
			 * userin browserdan gonderdigi veriler, oturum bilgileri, url talebi vs
			 * HttpContextAccessor bu httpcontext nesnesine erisim saglar
			 */
			#endregion
			#region Injections

			builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();

			builder.Services.AddScoped<IServiceManager, ServiceManager>();
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
			builder.Services.AddScoped<IOrderService, OrderService>();

			builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));//urettigin class sessiondan gelecek? GetCart()metodu icinde islettigim logic dahilinde bana cart.cs ver?
																		  //bana verecegin Cart.cs'i SessionCart.cs'teki GetCart() metodunun urettigi cart.cs'i ver.

			//Cart'ý singleton yaparsak runtime'da sadece 1 adet instance uretilecek herkes bunu kullanacak ornegin user a 2 urun, user b 4 urun ekledi, 2si de 6 urun gorecek. Bunu istemeyiz
			//o yuzden scoped olarak degistirelim ama bu kez de baska bir urun eklersek onceki urun kayboluyor cunku request basina newleme yapiliyor ve onceki nesne kayboluyor.
			//cart.cshtml.cs OnGet() metoduna bak.
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

			app.UseSession(); //sessionu aktif hale getirdik.

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

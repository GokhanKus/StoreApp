using Microsoft.EntityFrameworkCore;
using StoreApp.Business.AbstractServices;
using StoreApp.Business.ConcreteServices;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.ConcreteRepos;
using StoreApp.DataAccess.Context;
using StoreApp.Model.Entities;
using StoreAppUI.Models;

namespace StoreAppUI.ExtensionMethods
{
	public static class ServiceExtension
	{
		//artik bu configurationu program.cs'te yazmamiza gerek kalmadi
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("sqLiteConnection");
			services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("StoreAppUI")));
		}
		public static void ConfigureSession(this IServiceCollection services)
		{
			services.AddDistributedMemoryCache();//onbellek ekler, session icin user bilgilerini ram'de saklamak ve paylasmak icin tercih edilebilir
												 //Oturum yönetimi, kullanıcıların uygulama içindeki etkileşimleri sırasında belirli bilgileri tutma ve paylaşma mekanizmasıdır.
			services.AddSession(options =>
			{
				options.Cookie.Name = "StoreApp.Session";
				options.IdleTimeout = TimeSpan.FromMinutes(10);//userdan 10 dk icerisinden fresh bir request gelmezse oturumu sonlandir.
			});
			//services.AddHttpContextAccessor();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			#region HttpContextAccessor
			/*
			 * HttpContext nesnesine erisim saglar, bu nesne bir http requestin icerisinde barindirabilecegi cesitli bilgileri ve durumu temsil eder; 
			 * userin browserdan gonderdigi veriler, oturum bilgileri, url talebi vs
			 * HttpContextAccessor bu httpcontext nesnesine erisim saglar
			 */
			#endregion
			services.AddScoped<Cart>(c => SessionCart.GetCart(c));//urettigin class sessiondan gelecek? GetCart()metodu icinde islettigim logic dahilinde bana cart.cs ver?
			//bana verecegin Cart.cs'i SessionCart.cs'teki GetCart() metodunun urettigi cart.cs'i ver.
			//Cart'ı singleton yaparsak runtime'da sadece 1 adet instance uretilecek herkes bunu kullanacak ornegin user a 2 urun, user b 4 urun ekledi, 2si de 6 urun gorecek. Bunu istemeyiz
			//o yuzden scoped olarak degistirelim ama bu kez de baska bir urun eklersek onceki urun kayboluyor cunku request basina newleme yapiliyor ve onceki nesne kayboluyor.
			//cart.cshtml.cs OnGet() metoduna bak.
		}
		public static void ConfigureRepositoryInjections(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}
		public static void ConfigureServiceInjections(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IOrderService, OrderService>();
		}
	}
}

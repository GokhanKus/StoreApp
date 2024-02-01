using Microsoft.AspNetCore.Identity;
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
	//Pipeline(is hatti) her request bir middleware uzerinden gecer ve bir endpoint ile son bulur ve buna ait bir response uretilir.
	public static class ServiceExtension
	{
		//artik bu configurationu program.cs'te yazmamiza gerek kalmadi
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("sqLiteConnection");
			services.AddDbContext<StoreContext>(options =>
			{
				options.UseSqlite(connectionString, b => b.MigrationsAssembly("StoreAppUI"));
				options.EnableSensitiveDataLogging(true);
				//app gelistirme asamasinda username password gibi hassas bilgileri loglara yansitmaya ihtiyac duyabiliriz. simdilik true yapalim
			});
		}
		public static void ConfigureIdentityDbContext(this IServiceCollection services)
		{
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false; //kayit isleminden sonra e posta onaylama zorunlulugu olmasin
				options.User.RequireUniqueEmail = true; //mailler unique olsun her userin maili kendine ait olsun vs.
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false; //& % + gibi karakterler zorunlu olmasin
				options.Password.RequiredLength = 6; // min 6 karakter
			})
			.AddEntityFrameworkStores<StoreContext>();
		}
		public static void IdentityOptions(this IServiceCollection services) //program.cs'te bunu da cagirabiliriz onun yerine ustte conf ayarlarini yaptik farketmez.
		{
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireNonAlphanumeric = false; //özel karakter zorunlulugu olmasın
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;      //kucuk/buyuk harf zorunlulugu olmmasın
				options.Password.RequiredLength = 6;            //min 6 karakter

				options.User.RequireUniqueEmail = true; //aynı mail ile birden fazla kayit olusturulmasin
				options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.SignIn.RequireConfirmedEmail = true; //bu özelliği kapatınca onaylı olmayan hesaplarda result.IsLockedOut çalışıyor?
			});
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
			services.AddScoped<Cart>(c => SessionCart.GetCart(c));
			#region SessionCart Aciklama
			//urettigin class sessiondan gelecek? GetCart()metodu icinde islettigim logic dahilinde bana cart.cs ver?
			//bana verecegin Cart.cs'i SessionCart.cs'teki GetCart() metodunun urettigi cart.cs'i ver.
			//Cart'ı singleton yaparsak runtime'da sadece 1 adet instance uretilecek herkes bunu kullanacak ornegin user a 2 urun, user b 4 urun ekledi, 2si de 6 urun gorecek. Bunu istemeyiz
			//o yuzden scoped olarak degistirelim ama bu kez de baska bir urun eklersek onceki urun kayboluyor cunku request basina newleme yapiliyor ve onceki nesne kayboluyor.
			//cart.cshtml.cs OnGet() metoduna bak.
			#endregion
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
		public static void ConfigureRouting(this IServiceCollection services)
		{
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true; //urldeki action, controller vs buyuk harfle basliyordu baslamasini istemiyoruz. orn: output localhost/product/get olacak
				options.AppendTrailingSlash = false; //tue yapilirsa endpointin sonuna "/" koyar
			});
		}
	}
}

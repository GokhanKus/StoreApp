using StoreApp.Business.Mapper;
using StoreAppUI.ExtensionMethods;

namespace StoreAppUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			// Add services to the container.
			//API controller ifadeleri icin presentation layerda mvc projemize ekler?
			builder.Services.AddControllers()
				.AddApplicationPart(typeof(StoreApp.Presentation.AssemblyReference).Assembly); 

			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();							//artik controllerlar olmadan razor pageleri kullanabiliriz.

			builder.Services.ConfigureSqlServer(builder.Configuration); //ServiceExtension.cs'te konfigurasyon ayarini yaptik (onceden burada tanimlanirdi.)
			builder.Services.ConfigureIdentityDbContext();              //ServiceExtension.cs'te Identity configuration ayarlarini yaptik.
			builder.Services.ConfigureSession();					    //program.csteki session configure ayarlarini ServiceExtension.cs'te yaptik.
			builder.Services.ConfigureRepositoryInjections();			//ServiceExtension.cs'a tasindi
			builder.Services.ConfigureServiceInjections();              //ServiceExtension.cs'a tasindi
			builder.Services.ConfigureRouting();
			builder.Services.ConfigureApplicationCookie();

			//builder.Services.AddAutoMapper(typeof(Program));//automapper eklendi
			builder.Services.AddAutoMapper(typeof(MappingProfile)); // MappingProfile'� ekleyin

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseSession(); //sessionu aktif hale getirdik.

			app.UseRouting();

			app.UseAuthentication(); //once authentication sonra authorization yaz�l�r
			app.UseAuthorization(); //bu iki middleware Routing() ile EndPoints() aras�nda olmali

			/*Area'lar kucuk mvc projeleri olarak dusunulebilir.

			app.MapAreaControllerRoute(
				name: "Admin",
				areaName: "Admin",
				pattern: "Admin/{controller=DashBoard}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			*/
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
				);
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages(); //routing mekanizmas�nda bir problem yasamamamak icin ve endpointlerin uyusmasi icin bu satiri yazd�k.
				endpoints.MapControllers(); //API icin yazildi?
			});

			app.ConfigureAndCheckMigration();
			app.ConfigureLocalization();
			app.ConfigureDefaultAdminUser();

			app.Run();
		}
	}
}

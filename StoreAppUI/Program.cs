using StoreApp.Business.Mapper;
using StoreAppUI.ExtensionMethods;

namespace StoreAppUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.ConfigureDbContext(builder.Configuration);  //ServiceExtension.cs'te konfigurasyon ayarini yaptik (onceden burada tanimlanirdi.)

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();//artik controllerlar olmadan razor pageleri kullanabiliriz.

			builder.Services.ConfigureSession();//program.csteki session configure ayarlarini ServiceExtension.cs'te yaptik.

			builder.Services.ConfigureRepositoryInjections();   //ServiceExtension.cs'a tasindi
			builder.Services.ConfigureServiceInjections();      //ServiceExtension.cs'a tasindi

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
				endpoints.MapRazorPages(); //routing mekanizmasýnda bir problem yasamamamak icin ve endpointlerin uyusmasi icin bu satiri yazdýk.
			});

			app.ConfigureAndCheckMigration();

			app.Run();
		}
	}
}

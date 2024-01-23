using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreAppUI.ExtensionMethods;

namespace StoreAppUI.Pages
{
	public class DemoModel : PageModel
	{
		public string? FullName => HttpContext?.Session?.GetString("name") ?? "User"; 
		//readonly bir alan ihtiyac duyulan anda FullNameye deger atama islemini session uzerinden gerceklestiriyoruz.
		//session basladi mi baslamadi mi?, bir referans hatasi almamak adina null check operatorleri burada kullan�labilir.
        public void OnGet()
		{
			
		}
		public void OnPost([FromForm] string name) //demo.cshtml sayfasinda da name = "name" burada parametre olarak var Model Binding hat�rlatma
		{
			//textboxa isim girdik sayfa uzerinde gosterdi, fakat baska sayfaya gecip tekrar /Demo sayfas�na geldigimizde ismi gostermiyor, cunku
			//http requestleri geriye d�n�k olarak bizi hat�rlamaz, ismi haf�zada tutmak icin ismi tekrar gorebilmek icin session kullaniriz
			//FullName = name; o yuzden bu bilgiyi session uzerinde tutal�m

			HttpContext.Session.SetString("name",name);
			//set isleminde k�s�t�m�z var byte[], int ve string tipinde veri tutabiliyoruz,
			//eger class bilgisi tutmak istersen once serialize sonra deserialize islemi yapariz. (bunun icin ExtensionMethod klas�r� olusturduk)
		}

	}
}

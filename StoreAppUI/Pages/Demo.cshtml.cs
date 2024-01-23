using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreAppUI.Pages
{
	public class DemoModel : PageModel
	{
		public string? FullName => HttpContext?.Session?.GetString("name") ?? "User"; 
		//readonly bir alan ihtiyac duyulan anda FullNameye deger atama islemini session uzerinden gerceklestiriyoruz.
		//session basladi mi baslamadi mi?, bir referans hatasi almamak adina null check operatorleri burada kullanýlabilir.
        public void OnGet()
		{
			
		}
		public void OnPost([FromForm] string name) //demo.cshtml sayfasinda da name = "name" burada parametre olarak var Model Binding hatýrlatma
		{
			//textboxa isim girdik sayfa uzerinde gosterdi, fakat baska sayfaya gecip tekrar /Demo sayfasýna geldigimizde ismi gostermiyor, cunku
			//http requestleri geriye dönük olarak bizi hatýrlamaz, ismi hafýzada tutmak icin ismi tekrar gorebilmek icin session kullaniriz
			//FullName = name; o yuzden bu bilgiyi session uzerinde tutalým

			HttpContext.Session.SetString("name",name);
			//set isleminde kýsýtýmýz var byte[], int ve string tipinde veri tutabiliyoruz, eger class bilgisi tutmak istersen once serialize sonra deserialize islemi yapariz.
		}

	}
}

/*Session (Oturum) (Middleware) arayazilimdir
biz asp.net projelerinde  aslýnda http istekleri(requestleri) uzerine calisiyoruz, request ifadesi geliyor sonra sunucudan response ifadesi geliyor
uygun istekleri ve cevaplarý uretmek uzerýne programlama yapiyoruz
session bir middlewaredir ve istekler(requestler) ve yanýtlar(responseler) arasýnda iliski kurmaya izin veren bir yapý
http stateless(durumsuzdur) yani bir requestten sonra tekrar bir request atarsak sunucu bizi hatýrlamak zorunda degil 
eger hatýrlamasini istiyorsak request ve responseleri baglayacak bir yapiya ihtiyacimiz var o da sessionlardýr
*/

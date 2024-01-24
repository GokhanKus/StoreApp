using StoreApp.Model.Entities;
using StoreAppUI.ExtensionMethods;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace StoreAppUI.Models
{
	public class SessionCart : Cart
	{
		#region Json Ignore

		/* JsonIgnore
		 Bu ifade, SessionCart sýnýfýnda bulunan Session adlý özelliðin JSON serileþtirmesi sýrasýnda dikkate alýnmamasýný saðlar.
		JsonIgnore özelliði, JSON serileþtirmesi sýrasýnda belirli bir özelliðin atlanmasýný saðlayan bir özelliktir.

		Özellikle Session özelliðinin üzerinde bulunan [JsonIgnore] özniteliði, bu özelliðin JSON serileþtirmesi sýrasýnda dikkate alýnmamasýný istediðinizi belirtir.
		Yani, eðer bir nesne, örneðin bir SessionCart nesnesi, JSON formatýna dönüþtürülürken, bu özellik JSON çýktýsýnda yer almayacaktýr.

		Bu özellik, örneðin, bir nesnenin belirli durum bilgilerini içeriyorsa ve bu durum bilgilerinin dýþa aktarýlmasýný istemiyorsanýz veya 
		bu özelliði JSON çýktýsýndan hariç tutmak istiyorsanýz kullanýþlý olabilir. Bu sayede JSON çýktýsý daha temiz ve ihtiyaçlarý karþýlayan bir þekilde oluþturulabilir.
		*/

		#endregion
		[JsonIgnore]//sessionun tekrar kendisini yazmamasý icin 
		public ISession? Session { get; set; }
		public static Cart GetCart(IServiceProvider serviceProvider)//app calismaya baslarken belli servisler kullanilir. serviceProvider uzerinden ihtiyac duydugumuz servisi alacagiz.
		{
			ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session; //oturum(session) bilgilerini okuyalim, IHttpContextAccessor araciligiyla HttpContext nesnesine ve Session propuna erisim saglayalim
			SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart(); //burada session.GetJson(), SetJson() metotlari SessionExtension'dan geliyor(this ISession session) yazarak erisim saglandi?
			cart.Session = session;
			return cart;
		}
		public override void AddItem(Product product, int quantity)
		{
			base.AddItem(product, quantity); //base kýsmýnda kalýtým alýnan classtaki(Cart.cs) virtual metot calýrýs alttaki satirda extradan yapýlan islem vs.(override(metodu genisletiyoruz bir nevi.))
			Session?.SetJson<SessionCart>("cart", this);// veriyi sessiona yazmis oluyoruz. this = bu sýnýfýn kendisini serialize et
		}
		public override void Clear()
		{
			base.Clear();
			Session?.Remove("cart");
		}
		public override void RemoveLine(Product product)
		{
			base.RemoveLine(product);
			Session?.SetJson<SessionCart>("cart", this);
		}
	}
}

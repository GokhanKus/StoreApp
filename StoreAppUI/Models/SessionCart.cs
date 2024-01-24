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
		 Bu ifade, SessionCart s�n�f�nda bulunan Session adl� �zelli�in JSON serile�tirmesi s�ras�nda dikkate al�nmamas�n� sa�lar.
		JsonIgnore �zelli�i, JSON serile�tirmesi s�ras�nda belirli bir �zelli�in atlanmas�n� sa�layan bir �zelliktir.

		�zellikle Session �zelli�inin �zerinde bulunan [JsonIgnore] �zniteli�i, bu �zelli�in JSON serile�tirmesi s�ras�nda dikkate al�nmamas�n� istedi�inizi belirtir.
		Yani, e�er bir nesne, �rne�in bir SessionCart nesnesi, JSON format�na d�n��t�r�l�rken, bu �zellik JSON ��kt�s�nda yer almayacakt�r.

		Bu �zellik, �rne�in, bir nesnenin belirli durum bilgilerini i�eriyorsa ve bu durum bilgilerinin d��a aktar�lmas�n� istemiyorsan�z veya 
		bu �zelli�i JSON ��kt�s�ndan hari� tutmak istiyorsan�z kullan��l� olabilir. Bu sayede JSON ��kt�s� daha temiz ve ihtiya�lar� kar��layan bir �ekilde olu�turulabilir.
		*/

		#endregion
		[JsonIgnore]//sessionun tekrar kendisini yazmamas� icin 
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
			base.AddItem(product, quantity); //base k�sm�nda kal�t�m al�nan classtaki(Cart.cs) virtual metot cal�r�s alttaki satirda extradan yap�lan islem vs.(override(metodu genisletiyoruz bir nevi.))
			Session?.SetJson<SessionCart>("cart", this);// veriyi sessiona yazmis oluyoruz. this = bu s�n�f�n kendisini serialize et
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

﻿using System.Text.Json;

namespace StoreAppUI.ExtensionMethods
{
	public static class SessionExtension
	{
		//ozet bilgi, amac: verileri hafızada ve geriye yonelik requestleri hafızada tutmak ve konfigurasyon ayarları yapmak program.cs (orn. idletimeout)
		//bu classta ilgili fonksiyonları yazıyoruz.veriyi hafızaya alma veriyi getirme gibi islemler..

		//class bilgilerini tutmak icin once serialize sonra deserialize islemi yapariz. bu sinifi bunun icin olusturduk ve extension metotlar, classlar genelde static olarak tanimlanir.
		//ornek olmasi acisindan demo.cshtml.cs'te yaptigimiz ornegi dikkate alirsak orada yaptigimiz islemler icin burada metodunu olusturduk bu metot kullanilabilir.

		//this ISession session kısmını yazmazsak ISession'u genisletemeyiz yani bu metotlara erisim saglayamayiz(SessionCart.cs'te bu metotlar kullanildi.)
		public static void SetJson(this ISession session, string key, object value) 
		{
			session.SetString(key, JsonSerializer.Serialize(value));//object ile gelen value degerini cozumleyip (string'e cevirip -json formatina cevirip)veriyi sessionda hafızaya alıyoruz.
		}
		public static void SetJson<T>(this ISession session, string key, T value)
		{
			//ustteki metotla islevi aynidir bu sadece generic versiyonu bizden bir T tipi bekler.
			session.SetString(key, JsonSerializer.Serialize(value));
		}
		public static T? GetJson<T>(this ISession session, string key) where T : class
		{
			var data = session.GetString(key);
			return data is null
				? default(T)
				: JsonSerializer.Deserialize<T>(data); //deserialize ederek json formatindaki veriyi T tipine donusturur.
			#region 1.yontem
			//var data = session.GetString(key);
			//if (string.IsNullOrEmpty(data))
			//{
			//	return null;
			//}
			//T? value = JsonSerializer.Deserialize<T>(data);
			//return value;
			#endregion
		}
	}
}
/*
SetJson veya SetObject metodunu kullanırken ISession session parametresini dikkate almayız;
o kısım hangi veri tipinin,nesnenin genisletildigine karsilik gelir ve burada genisletilen ifade extension yazılan ifade ISession ifadesidir.
ISession yazmamızın sebebi HttpContext.Session kısmından sonra "." dedigimiz an ustteki metotlar gelir genisletmekten kasit budur.
*/
/*Session (Oturum) (Middleware) arayazilimdir. Session bilgiler tarayıcıya, kullaniciya ozeldir
biz asp.net projelerinde  aslında http istekleri(requestleri) uzerine calisiyoruz, request ifadesi geliyor sonra sunucudan response ifadesi geliyor
uygun istekleri ve cevapları uretmek uzerıne programlama yapiyoruz
session bir middlewaredir ve istekler(requestler) ve yanıtlar(responseler) arasında iliski kurmaya izin veren bir yapı
http stateless(durumsuzdur) yani bir requestten sonra tekrar bir request atarsak sunucu bizi hatırlamak zorunda degil 
eger hatırlamasini istiyorsak request ve responseleri baglayacak bir yapiya ihtiyacimiz var o da sessionlardır
*/
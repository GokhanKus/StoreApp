namespace StoreAppUI.ExtensionMethods
{
	public static class HttpRequestExtension
	{
        public static string PathAndQuery(this HttpRequest request)//bu HttpRequest classini genisletmek istiyoruz ya da bu metotu bu classa kazandırmak istiyoruz, verilen parametre bunun içindir.
		{
			PathString path = request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
			return path; //bu metot uygulamada kac tane product varsa o kadar calisiyor, cunku burayı productcard.cshtml uzerindeki sepete ekle butonunda cagiriyoruz ve her productcard olusurken burasi calisiyor (problem)
			//bu metodu ayrica product'ın details kisminda da cagiriyoruz (Get.cshtml) o zaman bir kere calisiyor problem yok.
			//return request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
		}
	}
}

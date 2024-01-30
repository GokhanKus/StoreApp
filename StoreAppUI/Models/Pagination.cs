namespace StoreAppUI.Models
{
	public class Pagination
	{
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        //tam bolunmedigi durumlar icin orn sonuc 2.3 cikarsa Ceiling ile yukariya yuvarlama islemi yapilsin boylece daha dogru bir hesaplama islemi yapilir.
        //public int TotalPages => TotalItems / ItemsPerPage;
    }
}

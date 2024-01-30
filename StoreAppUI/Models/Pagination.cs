namespace StoreAppUI.Models
{
	public class Pagination
	{
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => TotalItems / ItemsPerPage;
        //public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}

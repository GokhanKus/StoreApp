using System.ComponentModel.DataAnnotations;

namespace StoreAppUI.IdentityModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name field is required")]
        public string? UserName { get; set; }

		[Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
		public string? Password{ get; set; }

        //private string? _returnUrl;
        //public string ReturnUrl //kapsulleme
        //{
        //    get { return _returnUrl ?? "/"; }
        //    set { _returnUrl = value; } //ReturnUrl'e atanan degeri value araciligiyla _returnUrl'e atayalim
        //}
        public string? ReturnUrl { get; set; } = "/";
        public bool RememberMe { get; set; } = true;
    }
}

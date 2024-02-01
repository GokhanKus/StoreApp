using System.ComponentModel.DataAnnotations;

namespace StoreAppUI.IdentityModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name field is required")]
        public string? Name{ get; set; }

		[Required(ErrorMessage = "Password field is required")]
		public string? Password{ get; set; }

        private string? _returnUrl;
        public string ReturnUrl //kapsulleme
        {
            get { return _returnUrl ?? "/"; }
            set { _returnUrl = value; }
        }
    }
}

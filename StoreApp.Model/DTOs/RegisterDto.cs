using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.DTOs
{
	public record RegisterDto
	{
        [Required(ErrorMessage = "Username is required")]
        public string? UserName{ get; init; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email{ get; init; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password{ get; init; }

		[Required(ErrorMessage = "ConfirmPassword is required")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
		public string? ConfirmPassword { get; init; }
	}
}

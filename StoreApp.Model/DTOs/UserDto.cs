using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.DTOs
{
	public record UserDto
    {
        [Required]
		[DataType(DataType.Text)]
		public string? UserName { get; init; }

        [Required]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; init; }

		[DataType(DataType.PhoneNumber)]
		public string? PhoneNumber{ get; init; }

		public HashSet<string> Roles { get; set; } = new HashSet<string>(); //get;set; yapip yazmaya izin verelim
    }
}

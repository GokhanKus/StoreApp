using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.DTOs
{
	public record UserDtoForCreation : UserDto
	{
		[Required]
		[DataType(DataType.Password)]
        public string? Password  { get; init; }

		[Required]
		[DataType(DataType.Password)]
		[Compare(nameof(Password),ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword  { get; init; }
    }
}

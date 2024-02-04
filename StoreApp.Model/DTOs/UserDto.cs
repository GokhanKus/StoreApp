using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
		#region HashSet<string>
		/*
		HashSet<string> Türü:
			HashSet<string>, C# dilinde bir koleksiyon türüdür.
			string türünde elemanları içinde barındıran ve aynı elemanın bir küme içinde yalnızca bir kez bulunmasına izin veren bir veri yapısıdır.
		Başlangıç Değeri:
			= new HashSet<string>(); ifadesi, Roles özelliğine başlangıç değeri atar.
			new HashSet<string>() ifadesi, boş bir HashSet<string> örneğini oluşturur ve bu örneği Roles özelliğine atar.
		*/
		#endregion
	}
}

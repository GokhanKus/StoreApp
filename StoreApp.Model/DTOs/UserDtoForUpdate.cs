using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.DTOs
{
	public record UserDtoForUpdate :UserDto
	{
		//HashSet bir koleksiyon yapısıdır ve koleksiyon yapısı oldugu icin tekrar eden bir string ifadesi buraya eklenemez, küme teorisine gore calisir set seklinde ifade edilir.
        public HashSet<string> UserRoles{ get; set; } = new HashSet<string>();
    }
}

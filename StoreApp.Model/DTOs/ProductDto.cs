using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.DTOs
{
	public record ProductDto
	{
        //set olur ise immutable olma ozelligi saglanmaz, immutable olma ozelligi veriyi olustururken o verinin degismeyecegi yonunde garanti sunmus oluruz.
        //eger propler immutable olacaksa set; kısmı yerine init; yazarız ve o ozellik bize sadece nesne olusturulurken set etmemize izin verir
        //ama nesne olustuktan sonra nesne uzerınde degisiklik yapmamıza izin vermezi cunku immutable(degismez, sabit) yaptık
        public int Id { get; init; }

		[Required(ErrorMessage = "ProductName Field is required")]
		public string? ProductName { get; init; }

		[Required(ErrorMessage = "Price field is required")]
		public decimal Price { get; init; }
		public string? Summary { get; init; } = string.Empty; //init(initialize) aşamasında degeri verilecek sekilde ayarladık o yüzden init;
		public string? ImageUrl { get; set; } //ama resim atama islemini daha sonra yapacagim icin burası set; olarak kaldı
		public int? CategoryId { get; init; }     //Foreign Key
	}
}
/*
record tipler genelde dtolar icin kullanılır yani veri tasıma amacıyla kullanılır
record tipler kendi degerini degistiremeyen ve immutable olan tiplerdir.
Record tipleri, sınıf, constructor, equals, getHashCode ve ToString gibi genel metotları otomatik olarak oluşturarak kodun daha kısa ve anlaşılır olmasını sağlar.

init ozelligi, sadece constructor içinde başlatılmasını sağlar, ardından değerleri değiştirilemez.

 */
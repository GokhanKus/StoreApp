using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Entities
{
	public class Product:BaseEntity
    {
        [Required(ErrorMessage = "ProductName Field is required")]
        public string? ProductName { get; set; }

		[Required(ErrorMessage = "Price field is required")]
		public decimal Price{ get; set; }
        public int? CategoryId { get; set; }     //Foreign Key
        public Category? Category { get; set; } //Navigation Property
    }
}
//ilerleyen asamalarda validasyon islemlerini baska yerde yapacagiz bu classın sorumlulugu sadece entityleri (varlıklari)temsil etmektedir
//ayrıca single responsibility'e aykiri
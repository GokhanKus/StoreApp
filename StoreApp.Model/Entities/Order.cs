﻿using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Entities
{
	public class Order: BaseEntity
	{
		public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
		[Required(ErrorMessage = "Name field is required")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Line1 field is required")]
		public string? Line1 { get; set; }
        public string? Line2 { get; set; }
		public string? Line3 { get; set; }
		public string? City { get; set; }
		public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
    }
}

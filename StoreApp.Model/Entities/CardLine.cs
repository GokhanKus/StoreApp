using StoreApp.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Entities
{
	public class CardLine
	{
        public int CardLineId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
    }
}

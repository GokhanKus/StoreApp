﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Entities
{
	public class Cart
	{
		public List<CartLine> CartLines { get; set; }
		public Cart()
		{
			CartLines = new List<CartLine>();
		}
		public virtual void AddItem(Product product, int quantity)//metot imzası ilerde virtual olabilir, cunku bu metodu ezebiliriz.
		{
			CartLine? line = CartLines.Where(c => c.Product.Id == product.Id).FirstOrDefault();
			if (line is null)
			{
				CartLines.Add(new CartLine
				{
					Product = product,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}
		public virtual void RemoveLine(Product product) =>
			CartLines.RemoveAll(c => c.Product.Id == product.Id);
		public virtual void Clear() => //virtual keywordu, bir sınıf devralındıgında bir metodun bir propun geçersiz kılınmasini, override edilmesini saglamak amaciyla kullanılir.
			CartLines.Clear();
		public decimal ComputeTotalValue() =>
			CartLines.Sum(i => i.Product.Price * i.Quantity);
	}
}

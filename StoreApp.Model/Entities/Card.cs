using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.Entities
{
	public class Card
	{
		public List<CardLine> CardLines { get; set; }
		public Card()
		{
			CardLines = new List<CardLine>();
		}
		public void AddItem(Product product, int quantity)//metot imzası ilerde virtual olabilir, cunku bu metodu ezebiliriz.
		{
			CardLine? line = CardLines.Where(c => c.Product.Id == product.Id).FirstOrDefault();
			if (line is null)
			{
				CardLines.Add(new CardLine
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
		public void RemoveLine(Product product) =>
			CardLines.RemoveAll(c => c.Product.Id == product.Id);
		public decimal ComputeTotalValue() =>
			CardLines.Sum(i => i.Product.Price * i.Quantity);
		public void Clear() =>
			CardLines.Clear();
	}
}

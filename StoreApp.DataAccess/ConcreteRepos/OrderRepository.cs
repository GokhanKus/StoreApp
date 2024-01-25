using Microsoft.EntityFrameworkCore;
using StoreApp.DataAccess.AbstractRepos;
using StoreApp.DataAccess.Context;
using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.ConcreteRepos
{
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(StoreContext context) : base(context) //repositoryBase'in context'ini kullanalaım (ve o context de inject islemi ile db ile iletisimi saglacayacak.)
		{

		}
		public IQueryable<Order> Orders => _context.Orders //siparislere lineleri sonra line icinden productları dahil edip kargoya verilenlere gore sıraladık daha sonra son verilen siparislere gore siraladik.
			.Include(o => o.Lines)
			.ThenInclude(l => l.Product)
			.OrderBy(o => o.Shipped)
			.ThenByDescending(o => o.Id);

		public int NumberOfInProcess => _context.Orders //process asamasindaki(henuz kargoya verilmeyen) urunlerin sayisini alalim
			.Count(o => o.Shipped.Equals(false));

		public void Complete(int id) //tamamlanan order icin shipped(kargoya verildi) alanini true yapalim
		{
			var order = FindByCondition(o => o.Id.Equals(id), true);
			if (order is null) throw new Exception("order could not found");
			order.Shipped = true;
			//_context.SaveChanges(); save islemini service clasina bıraktık.
		}
		public Order? GetOneOrder(int id)
		{
			return FindByCondition(o => o.Id == id, false);
		}
		public void SaveOrder(Order order)
		{
			_context.AttachRange(order.Lines.Select(l => l.Product)); //contexte birden fazla kayit gelebilir o yuzden attachrange

			if (order.Id == 0) _context.Orders.Add(order);
			
			_context.SaveChanges();
		}
	}
}

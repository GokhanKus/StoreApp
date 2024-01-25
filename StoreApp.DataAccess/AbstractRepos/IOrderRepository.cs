using StoreApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.AbstractRepos
{
	public interface IOrderRepository
	{
		IQueryable<Order> Orders { get; }
		Order? GetOneOrder(int id);
		void Complete(int id);
		void SaveOrder(Order order);
		int NumberOfInProcess { get; }
	}
}

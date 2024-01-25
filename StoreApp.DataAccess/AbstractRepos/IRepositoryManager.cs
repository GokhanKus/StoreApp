using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.AbstractRepos
{
	public interface IRepositoryManager
	{
		IProductRepository Product { get; }
		ICategoryRepository Category { get; }
		IOrderRepository Order{ get; }
		public void Save();
	}
}

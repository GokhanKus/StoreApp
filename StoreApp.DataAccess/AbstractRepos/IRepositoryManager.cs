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
		public void Save();
	}
}

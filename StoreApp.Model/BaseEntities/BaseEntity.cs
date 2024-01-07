using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.BaseEntities
{
	public class BaseEntity : IEntity
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; } = DateTime.Now;
		public DateTime ModifiedTime { get; set; }
	}
}

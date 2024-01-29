using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.RequestParameters
{
	public class ProductRequestParameters: RequestParameters
	{
        public int? CategoryId { get; set; }
    }
}

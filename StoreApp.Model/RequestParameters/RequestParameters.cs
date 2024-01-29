using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Model.RequestParameters
{
	public abstract class RequestParameters
	{
        //buraya ortak olabilecek parametreler tanimlanacak, abstract oldugu icin newlenemez, bu sinifi kalitim alacak class newleyebilir
        public string? SearchingTerm { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	public class Factura
	{
		public int Id { get; set; }
		public List<Producto> ProductList { get; set; }
		public string NombreCliente { get; set; }
	}
}

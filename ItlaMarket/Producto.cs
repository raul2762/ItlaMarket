using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	public class Producto
	{
		public string Nombre { get; set; }
		public int Cantidad { get; set; }
		public double Precio { get; set; }
		public double subtotal { get; set; }
		public List<Producto> InventarioProd { get; set; }
	}
}

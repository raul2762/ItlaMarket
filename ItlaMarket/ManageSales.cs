using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ItlaMarket
{
	public class ManageSales : ICrud
	{
		private static ManageSales _instancia = null;
		public static ManageSales Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new ManageSales();
				}
				return _instancia;
			}
		}
		ManageClient manageClient = ManageClient.Instancia;
		ManageProduct manageProduct = ManageProduct.Instancia;
		public void Crear()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Para editar un cliente comience escribiendo el nombre");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Nombre de cliente: ");
			string nombre = Console.ReadLine();
			if (!string.IsNullOrEmpty(nombre))
			{
				bool result = manageClient.ConsultaCliente(nombre);
				if (result)
				{

					Console.Write("Nombre producto: ");
					string nombreProducto = Console.ReadLine();
					bool searchProduct = manageProduct.ConsultaProducto<bool>(nombreProducto, "nombre");
					if (searchProduct)
					{
						Console.Write("Cantidad: ");
						int cantProducto = Convert.ToInt32(Console.ReadLine());

						int stockProduct = manageProduct.ConsultaProducto<int>(nombreProducto, "cantidad");

						if (cantProducto > stockProduct)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("La cantidad introducida es mayor que el stock disponible: ", stockProduct);
						}
					}
					
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("**Cliente no encontrado**");
					Console.ReadKey();
					Crear();
				}
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("**entrada invalida**");
				Console.ReadKey();
				Crear();
			}
			
		}

		public void Listar()
		{

		}

		public void Editar()
		{

		}

		public void Eliminar()
		{

		}
	}
}

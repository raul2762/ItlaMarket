using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItlaMarket
{
	public class ManageProduct : ICrud
	{
		private static ManageProduct _instancia = null;

		List<Producto> productoLista = new List<Producto>();

		public static ManageProduct Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new ManageProduct();
				}
				return _instancia;
			}
		}
		public void Crear()
		{
			Producto producto = new Producto();
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			try
			{
				Console.Write("Nombre: ");
				producto.Nombre = Console.ReadLine();
				Console.Write("Cantidad: ");
				producto.Cantidad = Convert.ToInt32(Console.ReadLine());
				Console.Write("Precio: ");
				producto.Precio = Convert.ToDouble(Console.ReadLine());
				productoLista.Add(producto);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Producto guardado correctamente!");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write("Desea agregar otro producto 1-Si 2-No: ");
				int opcion = Convert.ToInt32(Console.ReadLine());
				switch (opcion)
				{
					case 1:
						Crear();
						break;
					case 2:
						MenuProductos.ShowMenu();
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Error! opcion invalida");
						Console.ReadKey();
						Crear();
						break;
				}

			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! {0}", ex.Message);
				Console.ReadKey();
				Crear();
			}

		}

		public void Listar()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Lista de producto en inventario");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("| Nombre | Cantidad | Precio");
			Console.WriteLine("*******************************");
			foreach (var item in productoLista)
			{
				Console.WriteLine("| {0} | {1} | {2} ", item.Nombre, item.Cantidad, item.Precio);
			}
			Console.WriteLine("Volver atras...");
			Console.ReadKey();
			MenuProductos.ShowMenu();
		}

		public void Editar()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Para editar un producto comience escribiendo el nombre");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Nombre de producto: ");
			string nombreProd = Console.ReadLine();

			var result = productoLista.FirstOrDefault(p => p.Nombre == nombreProd);
			int index = productoLista.IndexOf(result);
			if (result != null)
			{
				try
				{
					Console.WriteLine("Producto: Nombre: {0} Cant: {1} Precio: {2}", result.Nombre);
					Console.Write("Nombre: ");
					productoLista[index].Nombre = Console.ReadLine();
					Console.Write("Cantidad: ");
					productoLista[index].Cantidad = Convert.ToInt32(Console.ReadLine());
					Console.Write("Precio: ");
					productoLista[index].Precio = Convert.ToDouble(Console.ReadLine());
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Producto editado correctamente!");
					Console.ReadKey();
					Listar();
				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! {0}", ex.Message);
					Console.ReadKey();
					Listar();
				}

			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("**Producto no encontrado**");
				Console.ReadKey();
				MenuProductos.ShowMenu();
			}
		}

		public void Eliminar()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Para eliminar un producto comience escribiendo el nombre");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Nombre de producto: ");
			string nombreProd = Console.ReadLine();

			var result = productoLista.FirstOrDefault(p => p.Nombre == nombreProd);
			int index = productoLista.IndexOf(result);

			if (result != null)
			{
				try
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("***Nombre: {0} Cantidad: {1} Precios: {2}***", result.Nombre, result.Cantidad, result.Precio);
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write("Seguro que desea eliminar este articulo 1-Si 2-No: ");
					int opcion = Convert.ToInt32(Console.ReadLine());
					switch (opcion)
					{
						case 1:
							productoLista.RemoveAt(index);
							Listar();
							break;
						case 2:
							Listar();
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Error! opcion invalida");
							Console.ReadKey();
							Eliminar();
							break;
					}
				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! {0}", ex.Message);
					Console.ReadKey();
					Eliminar();
				}

			}
		}

		public T ConsultaProducto<T>(string nombreProducto, string tipoConsulta = "Nombre")
		{
			switch (tipoConsulta.ToLower())
			{
				case "nombre":
					var result = productoLista.FirstOrDefault(p => p.Nombre == nombreProducto);
					if (result != null)
					{
						return (T)(object)true;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("**Producto no encontrado**");
						Console.ReadKey();
						//ConsultaProducto<T>(nombreProducto, tipoConsulta);
						MenuVentas.ShowMenu();
					}
					break;
				case "cantidad":
					var result2 = productoLista.FirstOrDefault(p => p.Nombre == nombreProducto);
					if (result2 != null)
					{
						return (T)(object)result2.Cantidad;
					}
					break;
				case "precio":
					var result3 = productoLista.FirstOrDefault(p => p.Nombre == nombreProducto);
					if (result3 != null)
					{
						return (T)(object)result3.Precio;
					}
					break;
				default:
					break;
			}


			return (T)(object)false;
		}
	}
}

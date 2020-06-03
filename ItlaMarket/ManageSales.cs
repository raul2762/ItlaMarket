using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ItlaMarket
{
	public class ManageSales : ICrud
	{
		private static ManageSales _instancia = null;
		String[] persistenciaData = new string[3];
		List<Factura> facturaLista = new List<Factura>();
		List<Producto> productList = new List<Producto>();
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
		GeneradorId generadorId = GeneradorId.Instancia;
		public void Crear()
		{
			string nombre, nombreProducto;
			double precioProducto;
			Producto producto = new Producto();
			Factura factura = new Factura();
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Para editar un cliente comience escribiendo el nombre");
			Console.ForegroundColor = ConsoleColor.Cyan;
			if (string.IsNullOrEmpty(persistenciaData[0]))
			{
				Console.Write("Nombre de cliente: ");
				nombre = Console.ReadLine();
			}
			else
			{
				Console.WriteLine("Nombre de cliente: {0}", persistenciaData[0]);
				nombre = persistenciaData[0];
			}
			
			if (!string.IsNullOrEmpty(nombre))
			{
				bool result = manageClient.ConsultaCliente(nombre);
				if (result)
				{
					persistenciaData[0] = nombre;
					if (string.IsNullOrEmpty(persistenciaData[1]))
					{
						Console.Write("Nombre producto: ");
						nombreProducto = Console.ReadLine();
					}
					else
					{
						Console.WriteLine("Nombre producto: {0}", persistenciaData[1]);
						nombreProducto = persistenciaData[1];
					}
					
					bool searchProduct = manageProduct.ConsultaProducto<bool>(nombreProducto, "nombre");
					if (searchProduct)
					{
						precioProducto = manageProduct.ConsultaProducto<double>(nombreProducto, "precio");
						persistenciaData[1] = nombreProducto;
						producto.Nombre = nombreProducto;
						Console.Write("Cantidad: ");
						int cantProducto = Convert.ToInt32(Console.ReadLine());

						int stockProduct = manageProduct.ConsultaProducto<int>(nombreProducto, "cantidad");

						if (cantProducto > stockProduct)
						{
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("La cantidad introducida es mayor que el stock disponible: ", stockProduct);
							Console.WriteLine("1 - Introducir otra cantidad \n2 - Buscar otro producto \n3 - Cancelar venta");
							try
							{
								int opcion = Convert.ToInt32(Console.ReadLine());
								switch (opcion)
								{
									case 1:
										Crear();
										break;
									case 2:
										persistenciaData[1] = "";
										Crear();
										break;
									case 3:
										MenuPrincipal.ShowMenu();
										break;
									default:
										persistenciaData[0] = "";
										persistenciaData[1] = "";
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Error en factura.");
										Console.ReadKey();
										Crear();
										break;
								}
							}
							catch (Exception)
							{
								persistenciaData[0] = "";
								persistenciaData[1] = "";
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Error en factura.");
								Console.ReadKey();
								Crear();
							}
							
						}
						else
						{
							producto.Cantidad = cantProducto;
							producto.subtotal = cantProducto * precioProducto;
							producto.Precio = precioProducto;
							productList.Add(producto);
							Console.WriteLine("Agregar otro producto? 1-Si 2-No");
							try
							{
								int opcion = Convert.ToInt32(Console.ReadLine());
								switch (opcion)
								{
									case 1:
										persistenciaData[1] = "";
										Crear();
										break;
									case 2:
										
										persistenciaData[0] = "";
										persistenciaData[1] = "";
										factura.NombreCliente = nombre;
										factura.Id = generadorId.GetIdRnd();
										factura.ProductList = productList;
										productList.Clear();
										facturaLista.Add(factura);
										VentaCompletada(factura);
										break;
									default:
										persistenciaData[1] = "";
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Error en factura.");
										Console.ReadKey();
										MenuVentas.ShowMenu();
										break;
								}
							}
							catch (Exception)
							{
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("Error en factura.");
								Console.ReadKey();
								MenuVentas.ShowMenu();
							}
							
						}
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("**Producto no encontrado**");
						Console.ReadKey();
						Crear();
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

		private void VentaCompletada(Factura factura)
		{
			Console.Clear();
			double total = 0;
			Console.WriteLine("Factura id: {0}", factura.Id);
			Console.WriteLine("Factura completada a nombre de {0}", factura.NombreCliente);
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine("|Nombre | Cant | Precio | Subtotal");
			Console.WriteLine("----------------------------------------------------");
			foreach (var item in factura.ProductList)
			{
				Console.WriteLine("{0}     {1}     {2}     {3}",item.Nombre, item.Cantidad,item.Precio, item.subtotal);
				total += item.subtotal;
			}
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Total factura: {0}", total);
			Console.ReadKey();
			MenuPrincipal.ShowMenu();
		}

		public void showSales()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Ventas en el Sistema ItlaMarket");
			Console.WriteLine("---------------------------------------");
			Console.WriteLine("1 - Mostrar por cliente \n2 - Mostrar todos");
			int opcion = Convert.ToInt32(Console.ReadLine());

			switch (opcion)
			{
				case 1:
					Console.Write("Nombre cliente: ");
					string nombreCliente = Console.ReadLine();
					var result = facturaLista.FirstOrDefault(p => p.NombreCliente == nombreCliente);
					
					if (result != null)
					{
						var result2 = facturaLista.Where(p => p.NombreCliente == nombreCliente);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("Lista de Facturas cliente: {0}", nombreCliente);
						Console.WriteLine("---------------------------------------");
						foreach (var item in result2)
						{
							Console.WriteLine("Factura #{0}", item.Id);
						}
						Console.ReadKey();
						MenuPrincipal.ShowMenu();
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.WriteLine("Este cliente no tiene facturas en el sistema");
						Console.ReadKey();
						MenuPrincipal.ShowMenu();
					}
					

					break;
				case 2:
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("---------------------------------------");
					foreach (var item in facturaLista)
					{
						Console.WriteLine("#{0} {1}", item.Id, item.NombreCliente);
					}
					Console.ReadKey();
					MenuPrincipal.ShowMenu();
					break;
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Error! opcion invalida");
					Console.ReadKey();
					MenuPrincipal.ShowMenu();
					break;
			}
		}


	}
}

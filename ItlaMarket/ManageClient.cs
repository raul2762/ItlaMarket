using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItlaMarket
{
	public class ManageClient : ICrud
	{
		private static ManageClient _instancia = null;
		List<Cliente> clienteLista = new List<Cliente>();
		
		public static ManageClient Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new ManageClient();
				}
				return _instancia;
			}
		}
		public void Crear()
		{
			Cliente cliente = new Cliente();
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			try
			{
				Console.Write("Nombre: ");
				cliente.Nombre = Console.ReadLine();
				clienteLista.Add(cliente);
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Cliente guardado correctamente!");
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write("Desea crear otro cliente 1-Si 2-No: ");
				int opcion = Convert.ToInt32(Console.ReadLine());
				switch (opcion)
				{
					case 1:
						Crear();
						break;
					case 2:
						MenuClientes.ShowMenu();
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
			Console.WriteLine("Lista de clientes");
			if (clienteLista != null)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("| Nombre ");
				Console.WriteLine("*******************************");
				foreach (var item in clienteLista)
				{
					Console.WriteLine("| {0} ", item.Nombre);
				}
				Console.WriteLine("Volver atras...");
				Console.ReadKey();
				MenuClientes.ShowMenu();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("**No hay clientes registrados**");
				Console.ReadKey();
				MenuClientes.ShowMenu();
			}
			
		}

		public void Editar()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Para editar un cliente comience escribiendo el nombre");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Nombre de cliente: ");
			string nombreProd = Console.ReadLine();

			var result = clienteLista.FirstOrDefault(p => p.Nombre == nombreProd);
			int index = clienteLista.IndexOf(result);
			if (result != null)
			{
				try
				{
					Console.WriteLine("Cliente: {0} ", result.Nombre);
					Console.Write("Nombre: ");
					clienteLista[index].Nombre = Console.ReadLine();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Cliente editado correctamente!");
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
				Console.WriteLine("**Cliente no encontrado**");
				Console.ReadKey();
				MenuClientes.ShowMenu();
			}
		}

		public void Eliminar()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Para eliminar un cliente comience escribiendo el nombre");
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Write("Nombre de cliente: ");
			string nombreProd = Console.ReadLine();

			var result = clienteLista.FirstOrDefault(p => p.Nombre == nombreProd);
			int index = clienteLista.IndexOf(result);

			if (result != null)
			{
				try
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("***Nombre: {0} ***", result.Nombre);
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.Write("Seguro que desea eliminar este cliente 1-Si 2-No: ");
					int opcion = Convert.ToInt32(Console.ReadLine());
					switch (opcion)
					{
						case 1:
							clienteLista.RemoveAt(index);
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
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! cliente no encontrado");
				Console.ReadKey();
				Eliminar();
			}
		}

		public bool ConsultaCliente(string nombreCliente)
		{
			var result = clienteLista.FirstOrDefault(p => p.Nombre == nombreCliente);

			if (result != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

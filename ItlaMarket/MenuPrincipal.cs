using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	public class MenuPrincipal
	{
		public static void ShowMenu()
		{
			Console.Clear();
			try
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("1 - Clientes \n2 - Productos \n3 - Ventas \n4 - Salir");
				Console.Write("Digite una opcion: ");
				int opcion = Convert.ToInt32(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						MenuClientes.ShowMenu();
						break;
					case 2:
						MenuProductos.ShowMenu();
						break;
					case 3:
						MenuVentas.ShowMenu();
						break;
					case 4:
						Environment.Exit(0);
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Error! opcion invalida");
						Console.ReadKey();
						ShowMenu();
						break;
				}
			}
			catch (Exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! opcion invalida");
				Console.ReadKey();
				ShowMenu();
			}
			
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	public class MenuVentas
	{
		ManageSales manageSales = new ManageSales();
		public static void ShowMenu()
		{
			Console.Clear();
			try
			{
				ICrud manageSales = ManageSales.Instancia;
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("1 - Realizar venta \n2 - Historial de ventas");
				Console.Write("Digite una opcion: ");
				int opcion = Convert.ToInt32(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						manageSales.Crear();
						break;
					case 2:
						manageSales.Listar();
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

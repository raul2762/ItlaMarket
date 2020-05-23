using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	public class MenuClientes
	{
		public static void ShowMenu()
		{
			ICrud manageClient = new ManageClient();
			Console.Clear();
			try
			{
				
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("1 - Crear \n2 - Listar \n3 - Editar \n4 - Eliminar");
				Console.Write("Digite una opcion: ");
				int opcion = Convert.ToInt32(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						manageClient.Crear();
						break;
					case 2:
						manageClient.Listar();
						break;
					case 3:
						manageClient.Editar();
						break;
					case 4:
						manageClient.Eliminar();
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

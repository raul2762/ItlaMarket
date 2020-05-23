using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	public class MenuProductos
	{
		
		public static void ShowMenu()
		{
			ICrud manageProduct = ManageProduct.Instancia;
			Console.Clear();
			try
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("1 - Crear \n2 - Listar \n3 - Editar \n4 - Eliminar \n5 - Menu Principal");
				Console.Write("Digite una opcion: ");
				int opcion = Convert.ToInt32(Console.ReadLine());

				switch (opcion)
				{
					case 1:
						manageProduct.Crear();
						break;
					case 2:
						manageProduct.Listar();
						break;
					case 3:
						manageProduct.Editar();
						break;
					case 4:
						manageProduct.Eliminar();
						break;
					case 5:
						MenuPrincipal.ShowMenu();
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

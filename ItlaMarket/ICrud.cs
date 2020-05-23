using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaMarket
{
	interface ICrud
	{
		void Crear();
		void Listar();
		void Editar();
		void Eliminar();
	}
}

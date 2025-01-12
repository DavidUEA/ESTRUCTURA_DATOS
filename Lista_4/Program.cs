using System;
using System.Collections.Generic;

namespace Precios
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista de precios
            List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

            // Encontrar el precio mayor y menor
            int precioMayor = precios[0];
            int precioMenor = precios[0];

            foreach (int precio in precios)
            {
                if (precio > precioMayor)
                {
                    precioMayor = precio;
                }
                if (precio < precioMenor)
                {
                    precioMenor = precio;
                }
            }

            // Mostrar los resultados
            Console.WriteLine($"El precio mayor es: {precioMayor}");
            Console.WriteLine($"El precio menor es: {precioMenor}");

            // Esperar una tecla para cerrar
            Console.ReadKey();
        }
    }
}
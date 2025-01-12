using System;
using System.Collections.Generic;

namespace NumerosInversos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista para almacenar los números del 1 al 10
            List<int> numeros = new List<int>();

            // Llenar la lista con los números del 1 al 10
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            // Mostrar los números en orden inverso, separados por comas
            Console.WriteLine("Los números en orden inverso son:");
            for (int i = numeros.Count - 1; i >= 0; i--)
            {
                Console.Write(numeros[i]);
                if (i > 0)
                {
                    Console.Write(", ");
                }
            }

            // Esperar una tecla para cerrar
            Console.ReadKey();
        }
    }
}
﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear catálogo de revistas con 10 títulos en un HashSet
        HashSet<string> catalogo = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Innovación ", "Tecnología", "Hogar", "Aventuras",
            "Belleza", "Moda", "RHerramientas ", "Lectoras",
            "regalos", "Cumbias"
        };

        while (true)
        {
            Console.WriteLine("\n--- Catálogo de  ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Mostrar todos los títulos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "3")
                break;
            else if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string titulo = Console.ReadLine();
                Console.WriteLine(catalogo.Contains(titulo) ? "Encontrado" : "No encontrado");
            }
            else if (opcion == "2")
            {
                Console.WriteLine("\nLista de revistas en el catálogo:");
                foreach (var revista in catalogo)
                {
                    Console.WriteLine("- " + revista);
                }
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
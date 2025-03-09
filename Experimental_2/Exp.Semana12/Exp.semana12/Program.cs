
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, HashSet<string>> biblioteca = new Dictionary<string, HashSet<string>>();

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Registrar categoría");
            Console.WriteLine("2. Agregar libro a una categoría");
            Console.WriteLine("3. Mostrar categorías y libros");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre de la categoría: ");
                    string categoria = Console.ReadLine();
                    if (!biblioteca.ContainsKey(categoria))
                    {
                        biblioteca[categoria] = new HashSet<string>();
                        Console.WriteLine("Categoría registrada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("La categoría ya está registrada.");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese el nombre de la categoría: ");
                    categoria = Console.ReadLine();
                    if (biblioteca.ContainsKey(categoria))
                    {
                        Console.Write("Ingrese el nombre del libro: ");
                        string libro = Console.ReadLine();
                        if (biblioteca[categoria].Add(libro))
                        {
                            Console.WriteLine("Libro agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("El libro ya está en la categoría.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La categoría no existe.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\nCategorías y libros registrados:");
                    foreach (var entry in biblioteca)
                    {
                        Console.WriteLine($"Categoría: {entry.Key}");
                        foreach (var libro in entry.Value)
                        {
                            Console.WriteLine($"  - {libro}");
                        }
                    }
                    break;

                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }
}

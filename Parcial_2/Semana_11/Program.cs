
using System;
using System.Collections.Generic;

public class Traduc_basico
{
    private Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino/forma"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño/a"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto/tema"},
        {"government", "gobierno"},
        {"company", "empresa/compañía"}
    };

    public void Traducir()
    {
        Console.WriteLine("Ingrese la frase:");
        string frase = Console.ReadLine().ToLower(); // Convertir a minúsculas

        string[] palabras = frase.Split(' ');
        string fraseTraducida = "";

        foreach (string palabra in palabras)
        {
            if (diccionario.ContainsKey(palabra))
            {
                fraseTraducida += diccionario[palabra] + " ";
            }
            else
            {
                fraseTraducida += palabra + " "; // Si no está en el diccionario, se mantiene la palabra original
            }
        }

        Console.WriteLine("Su frase traducida es: " + fraseTraducida.Trim());
    }

    public void AgregarPalabra()
    {
        Console.WriteLine("Ingrese la palabra en inglés:");
        string palabraIngles = Console.ReadLine().ToLower();

        Console.WriteLine("Ingrese la traducción en español:");
        string palabraEspanol = Console.ReadLine().ToLower();

        diccionario[palabraIngles] = palabraEspanol;
        Console.WriteLine("Palabra agregada al diccionario correctamente.");
    }

    public void MostrarMenu()
    {
        Console.WriteLine("--------------------------MENU-------------------------");
        Console.WriteLine("=======================================================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Ingresar más palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.Write("-------------Seleccione una opción: -------------------");
    }

    public static void Main(string[] args)
    {
        Traduc_basico traduc = new Traduc_basico();
        int opcion;

        do
        {traduc.MostrarMenu();
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        traduc.Traducir();
                        break;
                    case 2:
                        traduc.AgregarPalabra();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
            Console.WriteLine();
        } while (opcion != 0);
    }
}
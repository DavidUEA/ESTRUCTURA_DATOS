using System;
using System.Collections.Generic;
using System.Linq; // Make sure to include this for string.Join

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 9, 11 };
        Console.WriteLine("Version original numeros:");
        Console.WriteLine(string.Join(" ", numeros)); // string.Join(" ", numeros)) imprime todos los numeros de la lista 
        numeros.Reverse();
        Console.WriteLine("\nReversa de numeros:");// luego de utilizar el metodo reverse imprime los numeros al contrario 
        Console.WriteLine(string.Join(" ", numeros)); 

        List<string> nombres = new List<string> { "Ana", "Juan", "Pedro", "David" };
        Console.WriteLine("\nVersion original nombres:");
        Console.WriteLine(string.Join(" ", nombres)); // // string.Join(" ", nombres)) imprime todos los nombres de la lista
        nombres.Reverse();
        Console.WriteLine("\nReversa de nombres:");//luego de utilizar el metodo reverse imprime los numeros al contrario
        Console.WriteLine(string.Join(" ", nombres)); 
        Console.ReadKey();
    }
}
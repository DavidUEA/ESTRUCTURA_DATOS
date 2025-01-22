using System;
using System.Collections.Generic;

public class EjemploLongitudLista
{
    public static int CalcularLongitud<T>(List<T> lista)
    {
        int contador = 0;
        foreach (T elemento in lista) /// recorre cada elemento de la lista
        {
            contador++; /// Incrementa el contador por cada elemento
        }
        return contador;
    }

    public static void Main(string[] args)
    {
        List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 9, 11 };
        int longitudNumeros = CalcularLongitud(numeros);
        Console.WriteLine($"La longitud de la lista de números es: {longitudNumeros}"); // Imprime: La longitud de la lista de números es: 7

        List<string> nombres = new List<string> { "Ana", "Juan", "Pedro", "David" };
        int longitudNombres = CalcularLongitud(nombres);
        Console.WriteLine($"La longitud de la lista de nombres es: {longitudNombres}"); // Imprime: La longitud de la lista de nombres es: 3

        ///List<double> valores = new List<double>(); // Lista vacía
        ///int longitudValores = CalcularLongitud(valores);
       /// Console.WriteLine($"La longitud de la lista vacía es: {longitudValores}"); // Imprime: La longitud de la lista vacía es: 0///
    }
}
using System;
using System.Collections.Generic;
public class TorresDeHanoi
{
    public static void Resolver(int n, char origen, char destino, char auxiliar)
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {origen} a {destino}");
            return;
        }
        Resolver(n - 1, origen, auxiliar, destino);
        Console.WriteLine($"Mover disco {n} de {origen} a {destino}");
        Resolver(n - 1, auxiliar, destino, origen);
    }
    public static void Main()
    {
        int discos = 3;
        Resolver(discos, 'A', 'C', 'B'); // A, B, C son las torres
    }
}
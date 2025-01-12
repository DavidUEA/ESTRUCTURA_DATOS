using System;
using System.Collections.Generic;

namespace AbecedarioEliminado
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista con las letras del abecedario
            List<char> abecedario = new List<char>();
            for (char letra = 'A'; letra <= 'Z'; letra++)
            {
                abecedario.Add(letra);
            }

            // Eliminar las letras en posiciones múltiplos de 3
            for (int i = abecedario.Count - 1; i >= 0; i--)
            {
                if ((i + 1) % 3 == 0)  // Las posiciones son base 1
                {
                    abecedario.RemoveAt(i);
                }
            }

            // Mostrar la lista resultante
            Console.WriteLine("El abecedario después de eliminar las letras en posiciones múltiplos de 3 es:");
            foreach (var letra in abecedario)
            {
                Console.Write(letra + " ");
            }

            // Esperar una tecla para cerrar
            Console.ReadKey();
        }
    }
}
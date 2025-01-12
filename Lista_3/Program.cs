using System;

namespace ContarVocales
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pedir al usuario una palabra
            Console.Write("Introduce una palabra: ");
            string palabra = Console.ReadLine().ToLower(); // Convertir la palabra a minúsculas para facilitar la comparación

            // Inicializar las variables para contar cada vocal
            int contadorA = 0, contadorE = 0, contadorI = 0, contadorO = 0, contadorU = 0;

            // Recorrer cada caracter de la palabra
            foreach (char letra in palabra)
            {
                // Comprobar y contar las vocales
                if (letra == 'a') contadorA++;
                else if (letra == 'e') contadorE++;
                else if (letra == 'i') contadorI++;
                else if (letra == 'o') contadorO++;
                else if (letra == 'u') contadorU++;
            }

            // Mostrar los resultados
            Console.WriteLine($"La letra 'a' aparece {contadorA} veces.");
            Console.WriteLine($"La letra 'e' aparece {contadorE} veces.");
            Console.WriteLine($"La letra 'i' aparece {contadorI} veces.");
            Console.WriteLine($"La letra 'o' aparece {contadorO} veces.");
            Console.WriteLine($"La letra 'u' aparece {contadorU} veces.");

            // Esperar una tecla para cerrar
            Console.ReadKey();
        }
    }
}
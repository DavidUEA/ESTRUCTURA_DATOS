using System;
using System.Collections.Generic;

namespace AsignaturasCurso
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista de asignaturas
            List<string> asignaturas = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Mostrar las asignaturas en la consola
            Console.WriteLine("Las asignaturas del curso son:");
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine(asignatura);
            }

            // Esperar una tecla para cerrar
            Console.ReadKey();
        }
    }
}
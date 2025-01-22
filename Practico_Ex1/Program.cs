 using System;
using System.Collections.Generic;

namespace AgendaTelefonica
{
    // Clase para representar un contacto
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email}";
        }
    }

    // Clase principal para gestionar la agenda telefónica
    public class Agenda
    {
        private List<Contacto> contactos;

        public Agenda()
        {
            contactos = new List<Contacto>();
        }

        // Método para agregar un nuevo contacto
        public void AgregarContacto(string nombre, string telefono, string email)
        {
            contactos.Add(new Contacto(nombre, telefono, email));
            Console.WriteLine("Contacto agregado exitosamente.");
        }

        // Método para visualizar todos los contactos
        public void VisualizarContactos()
        {
            Console.WriteLine("\nLista de Contactos:");
            if (contactos.Count == 0)
            {
                Console.WriteLine("No hay contactos registrados.");
                return;
            }

            foreach (var contacto in contactos)
            {
                Console.WriteLine(contacto);
            }
        }

        // Método para buscar un contacto por nombre
        public void BuscarContacto(string nombre)
        {
            var encontrados = contactos.FindAll(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (encontrados.Count == 0)
            {
                Console.WriteLine("No se encontraron contactos con ese nombre.");
            }
            else
            {
                Console.WriteLine("Contactos encontrados:");
                foreach (var contacto in encontrados)
                {
                    Console.WriteLine(contacto);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            string opcion;

            do
            {
                Console.WriteLine("\n--- Agenda Telefónica ---");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Visualizar contactos");
                Console.WriteLine("3. Buscar contacto");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el teléfono: ");
                        string telefono = Console.ReadLine();
                        Console.Write("Ingrese el email: ");
                        string email = Console.ReadLine();

                        agenda.AgregarContacto(nombre, telefono, email);
                        break;

                    case "2":
                        agenda.VisualizarContactos();
                        break;

                    case "3":
                        Console.Write("Ingrese el nombre a buscar: ");
                        string nombreBusqueda = Console.ReadLine();
                        agenda.BuscarContacto(nombreBusqueda);
                        break;

                    case "4":
                        Console.WriteLine("Saliendo de la agenda telefónica.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

            } while (opcion != "4");
        }
    }
}
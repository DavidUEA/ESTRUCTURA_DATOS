using System;
using System.Collections.Generic;


public class Persona /// representa la persona 
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

public class Atraccion /// nos permite asignar la cola de personas y asignar los puestos que corresponden 
{
    private Queue<Persona> cola = new Queue<Persona>(); /// es la que gestiona la cola de esperoa 
    private bool[] asientos = new bool[30]; // represetna un tamaño de capacidad 30 asientos, 

    public void AgregarPersona()///agrega una persona a la cola 
    {
        Console.Write("Ingrese el nombre de la persona: ");
        string nombre = Console.ReadLine();
        Persona persona = new Persona(nombre);
        cola.Enqueue(persona);/// que representa la cola de espera. El método Enqueue() añade un elemento al final de la cola.
        Console.WriteLine($"{persona.Nombre} se unió a la cola.");
    }

    public void AsignarAsientos()
    {
        while (cola.Count > 0)///  da asiganación a mientras exista personas en la cola 
        {
            Persona persona = cola.Dequeue();///etira el elemento que está al principio de la cola y lo devuelve. La persona retirada se guarda en la variable
            int asientoAsignado = -1;///Se inicializa la variable con el valor -1. Este valor se utilizará para indicar que aún no se ha encontrado un asiento disponible

            for (int i = 0; i < asientos.Length; i++)///itera el numeros de los 30 asientos del array asientos
            {
                if (!asientos[i])
                {
                    asientos[i] = true;
                    asientoAsignado = i + 1;
                    break;
                }
            }

            if (asientoAsignado != -1)
            {
                Console.WriteLine($"{persona.Nombre} ha sido asignado al asiento {asientoAsignado}.");
            }
            else
            {
                Console.WriteLine($"¡Todos los asientos están ocupados! {persona.Nombre} tendrá que esperar.");
                
            }
        }
    }

    public int CantidadPersonasEnCola()
    {
        return cola.Count; ///Esta línea devuelve la cantidad de elementos (personas) que hay en la col
    }

    public int AsientosDisponibles()
    {
        int disponibles = 0;//se utilizará para contar la cantidad de asientos disponibles. iniciando en 0
        foreach (bool ocupado in asientos)
        {
            if (!ocupado)
            {
                disponibles++;
            }
        }
        return disponibles;
    }

    public void MostrarEstadoAsientos()
    {
        Console.WriteLine("\nEstado de los asientos:");
        for (int i = 0; i < asientos.Length; i++)
        {
            Console.WriteLine($"Asiento {i + 1}: {(asientos[i] ? "Ocupado" : "Libre")}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Atraccion atraccion = new Atraccion();/// menu de usuario

        // Menú para interactuar con el usuario
        int opcion = 0;
        while (opcion != 5) // Se agrega la opción 5 para mostrar el estado de los asientos
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Agregar persona a la cola");
            Console.WriteLine("2. Asignar asientos");
            Console.WriteLine("3. Mostrar cantidad de personas en cola");
            Console.WriteLine("4. Mostrar asientos disponibles");
            Console.WriteLine("5. Mostrar estado de los asientos"); // Nueva opción
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        atraccion.AgregarPersona();
                        break;
                    case 2:
                        atraccion.AsignarAsientos();
                        break;
                    case 3:
                        Console.WriteLine($"Personas en cola: {atraccion.CantidadPersonasEnCola()}");
                        break;
                    case 4:
                        Console.WriteLine($"Asientos disponibles: {atraccion.AsientosDisponibles()}");
                        break;
                    case 5:
                        atraccion.MostrarEstadoAsientos(); // Se llama al nuevo método
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Ingrese un número.");
            }
        }
    }
}
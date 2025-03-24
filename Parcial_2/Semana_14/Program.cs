using System;
using System.Collections.Generic;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo, Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

class ArbolBinarioCompleto
{
    private Nodo raiz;
    private Queue<Nodo> cola; // Para asegurar balance en la inserción

    public ArbolBinarioCompleto()
    {
        raiz = null;
        cola = new Queue<Nodo>();
    }

    public void Insertar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (raiz == null)
        {
            raiz = nuevoNodo;
        }
        else
        {
            Nodo frente = cola.Peek();
            if (frente.Izquierdo == null)
                frente.Izquierdo = nuevoNodo;
            else if (frente.Derecho == null)
            {
                frente.Derecho = nuevoNodo;
                cola.Dequeue(); // Remover nodo lleno
            }
        }
        cola.Enqueue(nuevoNodo);
    }

    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null) return false;
        if (nodo.Valor == valor) return true;
        return BuscarRec(nodo.Izquierdo, valor) || BuscarRec(nodo.Derecho, valor);
    }

    public void InOrden()
    {
        InOrdenRec(raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InOrdenRec(nodo.Derecho);
        }
    }

    public void PreOrden()
    {
        PreOrdenRec(raiz);
        Console.WriteLine();
    }

    private void PreOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreOrdenRec(nodo.Izquierdo);
            PreOrdenRec(nodo.Derecho);
        }
    }

    public void PostOrden()
    {
        PostOrdenRec(raiz);
        Console.WriteLine();
    }

    private void PostOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRec(nodo.Izquierdo);
            PostOrdenRec(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public int ContarNodos()
    {
        return ContarNodosRec(raiz);
    }

    private int ContarNodosRec(Nodo nodo)
    {
        if (nodo == null) return 0;
        return 1 + ContarNodosRec(nodo.Izquierdo) + ContarNodosRec(nodo.Derecho);
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioCompleto arbol = new ArbolBinarioCompleto();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- Menú Árbol Binario Completo ---");
            Console.WriteLine("1. Insertar un nodo");
            Console.WriteLine("2. Buscar un nodo");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Contar nodos");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Nodo encontrado" : "Nodo no encontrado");
                    break;
                case 3:
                    Console.WriteLine("Recorrido Inorden: ");
                    arbol.InOrden();
                    break;
                case 4:
                    Console.WriteLine("Recorrido Preorden: ");
                    arbol.PreOrden();
                    break;
                case 5:
                    Console.WriteLine("Recorrido Postorden: ");
                    arbol.PostOrden();
                    break;
                case 6:
                    Console.WriteLine("Número total de nodos: " + arbol.ContarNodos());
                    break;
                case 7:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        } while (opcion != 7);
    }
}
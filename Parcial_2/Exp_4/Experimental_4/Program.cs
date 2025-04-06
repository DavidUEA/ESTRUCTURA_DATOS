using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralidadGrafos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definir el grafo como lista de adyacencias
            var grafo = new Dictionary<string, List<string>>
            {
                ["A"] = new List<string> { "B", "C" },
                ["B"] = new List<string> { "A", "C", "D" },
                ["C"] = new List<string> { "A", "B", "D", "E" },
                ["D"] = new List<string> { "B", "C", "E" },
                ["E"] = new List<string> { "C", "D" }
            };

            Console.WriteLine("CENTRALIDAD DE GRADO");
            foreach (var nodo in grafo.Keys)
            {
                Console.WriteLine($"Nodo {nodo}: {grafo[nodo].Count}");
            }

            Console.WriteLine("\nCENTRALIDAD DE CERCANÍA");
            foreach (var nodo in grafo.Keys)
            {
                double cercania = CalcularCercania(nodo, grafo);
                Console.WriteLine($"Nodo {nodo}: {cercania:F3}");
            }

            Console.WriteLine("\nCENTRALIDAD DE INTERMEDIACIÓN (APROXIMADA)");
            var intermediacion = CalcularIntermediacion(grafo);
            foreach (var kvp in intermediacion)
            {
                Console.WriteLine($"Nodo {kvp.Key}: {kvp.Value}");
            }
        }

        // Cálculo de centralidad de cercanía usando BFS
        static double CalcularCercania(string nodoInicio, Dictionary<string, List<string>> grafo)
        {
            var distancias = new Dictionary<string, int>();
            var visitados = new HashSet<string>();
            var cola = new Queue<(string nodo, int distancia)>();
            cola.Enqueue((nodoInicio, 0));

            while (cola.Count > 0)
            {
                var (nodoActual, distancia) = cola.Dequeue();
                if (visitados.Contains(nodoActual)) continue;

                visitados.Add(nodoActual);
                distancias[nodoActual] = distancia;

                foreach (var vecino in grafo[nodoActual])
                {
                    if (!visitados.Contains(vecino))
                        cola.Enqueue((vecino, distancia + 1));
                }
            }

            int sumaDistancias = distancias.Values.Sum();
            return sumaDistancias > 0 ? 1.0 / sumaDistancias : 0;
        }

        // Cálculo aproximado de centralidad de intermediación
        static Dictionary<string, int> CalcularIntermediacion(Dictionary<string, List<string>> grafo)
        {
            var intermediacion = grafo.Keys.ToDictionary(k => k, k => 0);

            var nodos = grafo.Keys.ToList();
            for (int i = 0; i < nodos.Count; i++)
            {
                for (int j = 0; j < nodos.Count; j++)
                {
                    if (i == j) continue;
                    var caminos = EncontrarCaminosMinimos(nodos[i], nodos[j], grafo);
                    foreach (var camino in caminos)
                    {
                        foreach (var nodo in camino.Skip(1).Take(camino.Count - 2)) // Excluir origen y destino
                        {
                            intermediacion[nodo]++;
                        }
                    }
                }
            }

            return intermediacion;
        }

        // Encuentra todos los caminos más cortos entre dos nodos usando BFS
        static List<List<string>> EncontrarCaminosMinimos(string inicio, string fin, Dictionary<string, List<string>> grafo)
        {
            var caminos = new List<List<string>>();
            var cola = new Queue<List<string>>();
            cola.Enqueue(new List<string> { inicio });
            var visitados = new Dictionary<string, int> { [inicio] = 0 };

            while (cola.Count > 0)
            {
                var camino = cola.Dequeue();
                var ultimo = camino.Last();

                if (ultimo == fin)
                {
                    caminos.Add(camino);
                    continue;
                }

                foreach (var vecino in grafo[ultimo])
                {
                    var nuevoCamino = new List<string>(camino) { vecino };

                    if (!visitados.ContainsKey(vecino) || visitados[vecino] >= nuevoCamino.Count - 1)
                    {
                        visitados[vecino] = nuevoCamino.Count - 1;
                        cola.Enqueue(nuevoCamino);
                    }
                }
            }

            int menorLongitud = caminos.Count > 0 ? caminos.Min(c => c.Count) : 0;
            return caminos.Where(c => c.Count == menorLongitud).ToList();
        }
    }
}

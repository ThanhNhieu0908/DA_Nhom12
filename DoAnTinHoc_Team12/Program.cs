using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DoAn
{
    public class Program
    {
        static int[,] Matrix()
        {
            Random random = new Random();
            int m = random.Next(6, 10);
            int n = random.Next(6, 10);
            int[,] matrix = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(1, 12);
                }
            }
            return matrix;
        }

        static void printMatrix(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        static Dictionary<int, List<(int, int)>> buidGraph(int[,] grid)
        {
            int m = grid.GetLength(0);
            int n = grid.GetLength(1);
            var graph = new Dictionary<(int, int), List<((int, int), int)>>();
            for (int i = 0; i < m;i++)
            {
               
                for(int j = 0; j < n; j++)
                {
                    var neighbors = new List<((int, int), int)>();

                    for (int k = 0; k < 4; k++)
                    {
                        int x = i + dx[k];
                        int y = j + dy[k];

                        if (x >= 0 && x < m && y >= 0 && y < n)
                        {
                            neighbors.Add(((x, y), grid[x, y]));
                        }
                    }

                    graph[(i, j)] = neighbors;
                }
                
            }
            return graph;
        }

        static void printGraph(Dictionary<int, List<(int, int)>> graph)
        {
            foreach (var key in graph.Keys)
            {
                foreach(var value in graph[key])
                {
                    Console.Write($"({value.Item1}|{value.Item2}) ");
                }
                Console.WriteLine();
            }
        }

        static (Dictionary<(int, int), int>, Dictionary<(int, int), (int, int)>)
         dijkstra(Dictionary<(int, int), List<((int, int), int)>> graph, (int, int) start)
        {
            var dist = new Dictionary<(int, int), int>();
            var prev = new Dictionary<(int, int), (int, int)>();
            var pq = new PriorityQueue<(int, int), int>();

            foreach (var node in graph.Keys)
                dist[node] = int.MaxValue;

            dist[start] = 0;
            pq.Enqueue(start, 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out (int, int) current, out int currentDist);

                if (currentDist > dist[current]) continue;

                foreach (var edge in graph[current])
                {
                    var neighbor = edge.Item1;
                    var weight = edge.Item2;

                    int newDist = currentDist + weight;

                    if (newDist < dist[neighbor])
                    {
                        dist[neighbor] = newDist;
                        prev[neighbor] = current;
                        pq.Enqueue(neighbor, newDist);
                    }
                }
            }

            return (dist, prev);
        }

        static void Main(string[] args)
        {
            int[,] matrix = Matrix();
            printMatrix(matrix);
        }
    }
}
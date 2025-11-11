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
            var graph = new Dictionary<int, List<(int, int)>>();
            for(int i = 0; i < m;i++)
            {
                var node = new List<int>();
                for(int j = 0; j < n; j++)
                {
                    if(grid[i, j] == 0) continue;
                    node.Add((j, grid[i, j]);
                }
                graph[i] = node;
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

        static (Dictionary<(int, int), int> dist, Dictionary<(int, int), (int, int)> prev) dijkstra(Dictionary<(int, int), List<((int, int) neighbor, int weight)>> graph, (int, int) start)
        {
            var dist = new Dictionary<(int, int), int>();
            var prev = new Dictionary<(int, int), (int, int)>();
            var priorityQueue = new PriorityQueue<(int, int), int>();

            foreach (var node in graph.Keys)
            {
                dist[node] = int.MaxValue;
            }
            dist[start] = 0;
            priorityQueue.Enqueue(start, 0);
            while (priorityQueue.Count > 0)
            {
                priorityQueue.TryDequeue(out (int, int) current, out int currentDist);
                if (currentDist > dist[current])
                {
                    continue;
                }
                foreach (var value in graph[current])
                {
                    int newDist = currentDist + value.weight;
                    if (newDist < dist[value.neighbor])
                    {
                        dist[value.neighbor] = newDist;
                        prev[value.neighbor] = current;
                        priorityQueue.Enqueue(value.neighbor, newDist);
                    }
                }
            }
            return (dist, prev);
        }

        static void main(string[] args)
        {
            int[,] matrix = Matrix();
            printMatrix(matrix);
        }
    }
}
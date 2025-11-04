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
        static void readInput(string path, out int[,] grid, out int start, out int end)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentNullException("input file missing grid data lines.");
            }
            string[] line = File.ReadAllLines(path);
            int indexLine = 0;
            string[] size = line[indexLine++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int m = int.Parse(size[0]);
            int n = int.Parse(size[1]);
            string[] startAndEnd = line[indexLine++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            start = int.Parse(startAndEnd[0]);
            end = int.Parse(startAndEnd[1]);
            grid = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                string[] part = line[indexLine++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < n; k++)
                {
                    grid[i, k] = int.Parse(part[k]);
                }
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

        static void main(string[] args)
        {
            string inputPath = "input.txt";
            readInput(inputPath, out int[,] grid, out int start, out int end);
            var graph = buidGraph(grid);
            printGraph(graph);
        }
    }
}
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
    internal class Program
    {
<<<<<<< HEAD
        static void readInput(string path, out int[,] grid, out (int, int) start, out (int, int) end, out List<(int, int)> mustVisit)
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
            start = (int.Parse(startAndEnd[0]), int.Parse(startAndEnd[1]));
            end = (int.Parse(startAndEnd[2]), int.Parse(startAndEnd[3]));
            int mustCount = int.Parse(line[indexLine++]);
            mustVisit = new List<(int, int)>();
            for (int i = 0; i < mustCount; i++)
            {
                string[] coords = line[indexLine++].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                mustVisit.Add((int.Parse(coords[0]), int.Parse(coords[1])));
            }
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
    }
}
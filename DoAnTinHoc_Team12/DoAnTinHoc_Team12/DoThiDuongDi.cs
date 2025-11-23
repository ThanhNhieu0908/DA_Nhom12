using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Team12
{
    public class DoThiDuongDi<T>
    {
     
            public static (Dictionary<T, double>, List<T>) Dijkstra(DoThi<T> graph, T start, T end)
            {
                var dist = new Dictionary<T, double>();
                var prev = new Dictionary<T, T>();
                var visited = new HashSet<T>();

                foreach (var vertex in graph.DanhSachKe.Keys)
                {
                    dist[vertex] = double.MaxValue;
                    prev[vertex] = default(T);
                }

                dist[start] = 0;

                while (visited.Count < graph.DanhSachKe.Count)
                {
                    // Chọn đỉnh có dist nhỏ nhất chưa đi đến
                    T u = dist.Where(x => !visited.Contains(x.Key))
                              .OrderBy(x => x.Value)
                              .First().Key;

                    visited.Add(u);

                    if (EqualityComparer<T>.Default.Equals(u, end))
                        break;

                    foreach (var edge in graph.DanhSachKe[u])
                    {
                        var v = edge.CanhKe;
                        double w = edge.TrongSo;

                        if (!visited.Contains(v) &&
                            dist[u] + w < dist[v])
                        {
                            dist[v] = dist[u] + w;
                            prev[v] = u;
                        }
                    }
                }

                // Truy vết đường đi
                var path = new List<T>();
                T current = end;

                while (!EqualityComparer<T>.Default.Equals(current, default(T)))
                {
                    path.Insert(0, current);
                    current = prev[current];

                    if (EqualityComparer<T>.Default.Equals(current, default(T)))
                        break;
                }

                path.Insert(0, start);

                return (dist, path);
            }
        }
    }


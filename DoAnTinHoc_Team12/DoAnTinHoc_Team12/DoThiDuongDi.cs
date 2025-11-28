using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Team12
{
    public class DoThiDuongDi
    {

        public static (Dictionary<int, double>, List<int>, string) Dijkstra(DoThi graph, int start, int end, List<Canh> u)
        {
            var dist = new Dictionary<int, double>();
            var priority = new PriorityQueue<int, double>();
            var prev = new Dictionary<int, int>();
            var visited = new HashSet<int>();
            var log = new StringBuilder();

            // Khởi tạo
            foreach (var node in graph.DanhSachKe.Keys)
                dist[node] = double.MaxValue;

            dist[start] = 0;
            priority.Enqueue(start, 0);
            log.AppendLine($"Khởi tạo: dist[{start}] = 0");

            while (priority.Count > 0)
            {
                priority.TryDequeue(out int node, out double minDist);

                log.AppendLine($"Lấy đỉnh {node} ra khỏi hàng đợi với dist = {minDist}");
                visited.Add(node);
                if(node == end)
                {
                    break;
                }
                if (minDist > dist[node])
                {
                    continue;
                }
                foreach (var value in graph.DanhSachKe[node])
                {
                    double newDist = minDist + value.TrongSo;
                    if (newDist < dist[value.Dinh])
                    {
                        dist[value.Dinh] = newDist;
                        prev[value.Dinh] = node;
                        priority.Enqueue(value.Dinh, newDist);
                        log.AppendLine($"Cập nhật {value.Dinh}: dist mới = {newDist}");
                    }
                    else
                    {
                        log.AppendLine(
                            $"Bỏ qua {value.Dinh}: dist hiện tại {dist[value.Dinh]} tốt hơn {newDist}"
                        );
                    }
                }
            }

            // reconstruct path
            var path = new List<int>();
            int curr = end;

            if (!prev.ContainsKey(curr) && !curr.Equals(start))
            {
                log.AppendLine("Không tìm thấy đường đi!");
                return (dist, new List<int>(), log.ToString());
            }

            path.Insert(0, curr);
            while (!curr.Equals(start))
            {
                curr = prev[curr];
                path.Insert(0, curr);
            }

            log.AppendLine(
                $"Đường đi: {string.Join(" -> ", path)} | Tổng trọng số: {dist[end]}"
            );

            return (dist, path, log.ToString());
        }

    }
}


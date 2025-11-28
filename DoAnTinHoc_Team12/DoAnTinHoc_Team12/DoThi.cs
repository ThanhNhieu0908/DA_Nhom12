using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Team12
{
    public class DoThi
    {
        public Dictionary<int, List<Canh>> DanhSachKe { get; set; }
        private Random rd = new Random();

        public DoThi()
        {
            DanhSachKe = new Dictionary<int, List<Canh>>();
        }

        public void ThemDinh(int dinh)
        {
            if (!DanhSachKe.ContainsKey(dinh))
                DanhSachKe[dinh] = new List<Canh>();
        }
         public void ThemCanh(int from, int to, double trongSo)
        {
            ThemDinh(from);
            ThemDinh(to);
            DanhSachKe[from].Add(new Canh(to, trongSo));
        }

        // Random đồ thị hoàn chỉnh (đầy đủ cạnh)
        public void TaoNgauNhien(List<int> danhSachDinh)
        {
            foreach (var u in danhSachDinh)
            {
                foreach (var v in danhSachDinh)
                {
                    double w = rd.Next(1, 20);
                    ThemCanh(u, v, w);
                }
            }
        }

    }
}


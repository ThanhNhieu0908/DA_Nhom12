using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Team12
{
    public class DoThi<T>
    {
        public Dictionary<T, List<Canh<T>>> DanhSachKe { get; set; }
        private Random rd = new Random();

        public DoThi()
        {
            DanhSachKe = new Dictionary<T, List<Canh<T>>>();
        }

        public void ThemDinh(T dinh)
        {
            if (!DanhSachKe.ContainsKey(dinh))
                DanhSachKe[dinh] = new List<Canh<T>>();
        }

        public void ThemCanh(T from, T to, double trongSo)
        {
            ThemDinh(from);
            ThemDinh(to);
            DanhSachKe[from].Add(new Canh<T>(to, trongSo));
        }

        // Random đồ thị hoàn chỉnh (đầy đủ cạnh)
        public void TaoNgauNhien(List<T> danhSachDinh)
        {
            foreach (var u in danhSachDinh)
            {
                foreach (var v in danhSachDinh)
                {
                    if (!EqualityComparer<T>.Default.Equals(u, v))
                    {
                        double w = rd.Next(1, 20);
                        ThemCanh(u, v, w);
                    }
                }
            }
        }

    }
}


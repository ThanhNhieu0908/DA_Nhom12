using System;
using System.Collections.Generic;
using System.Globalization;
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
         public void ThemCanh(int from, int to, int trongSo)
        {
            ThemDinh(from);
            ThemDinh(to);
            DanhSachKe[from].Add(new Canh(to, trongSo));
        }

        // Random đồ thị
        public void TaoNgauNhien(int soLuongDinh)
        {
            DanhSachKe.Clear();
            int bacToiDa = 3;
            for(int i = 1; i <= soLuongDinh; i++)
            {
                ThemDinh(i);
            }
            for(int i = 1; i < soLuongDinh; i++)
            {
                int trongSo = rd.Next(1, 20);
                ThemCanh(i, i + 1, trongSo);
            }
            for(int u = 1; u <= soLuongDinh; u++)
            {
                int soBac = rd.Next(1, bacToiDa);
                while (DanhSachKe[u].Count < soBac)
                {
                    int v = rd.Next(1, soLuongDinh);
                    if(u != v && !KiemTraCanhTonTai(u, v))
                    {
                        int trongSo = rd.Next(1, 20);
                        ThemCanh(u, v, trongSo);
                    }
                }
            }
        }

        private bool KiemTraCanhTonTai(int u, int v)
        {
            foreach (var canh in DanhSachKe[u])
            {
                if(canh.Dinh == v)
                {
                    return true;
                }
            }
            return false;
        }
    }
}


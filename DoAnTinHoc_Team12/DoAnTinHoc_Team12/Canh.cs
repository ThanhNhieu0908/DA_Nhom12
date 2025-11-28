using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Team12
{
    public class Canh
    {
        private int dinh;
        private double _trongSo;

        public Canh()
        {
            dinh = 0;
            TrongSo = 0;
        }

        public Canh(int dinh, double trongSo)
        {
            Dinh = dinh;
            TrongSo = trongSo;
        }
        public double TrongSo { get => _trongSo; set => _trongSo = value; }
        public int Dinh { get => dinh; set => dinh = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTinHoc_Team12
{
    public class Canh<T>
    {
        private T? _canhKe;
        private double _trongSo;

        public Canh() { }

        public Canh(T canhKe, double trongSo)
        {
            CanhKe = canhKe;
            TrongSo = trongSo;
        }
        public double TrongSo { get => _trongSo; set => _trongSo = value; }
        public T? CanhKe { get => _canhKe; set => _canhKe = value; }
    }
}

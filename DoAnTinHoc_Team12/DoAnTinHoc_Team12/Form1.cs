

using System.Net.Http.Headers;
using System.Windows.Forms;

namespace DoAnTinHoc_Team12
{
    public partial class Form1 : Form
    {
        private DoThi graph;
        private List<Canh> canh;

        public Form1()
        {
            InitializeComponent();

            graph = new DoThi();
            canh = new List<Canh>();

            // Tạo danh sách đỉnh 1-5
            var dsDinh = new List<int> { 1, 2, 3, 4, 5 };
            graph.TaoNgauNhien(dsDinh);

            HienThiDoThi();
        }
        private void TaoViTriNut()
        {
            viTriNut = new Dictionary<int, Point>();

            int n = graph.DanhSachKe.Count;
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;
            int radius = Math.Min(centerX, centerY) - 50;

            int i = 0;
            foreach (var node in graph.DanhSachKe.Keys)
            {
                double angle = 2 * Math.PI * i / n;

                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));

                viTriNut[node] = new Point(x, y);
                i++;
            }
        }


        private void btnTinhDuongDi_Click(object sender, EventArgs e)
        {
            try
            {
                int start = int.Parse(txtStart.Text);
                int end = int.Parse(txtEnd.Text);

                var (dist, path, log) = DoThiDuongDi.Dijkstra(graph, start, end, canh);

                // Hiển thị kết quả
                txtKetQua.Clear();
                txtKetQua.AppendText($"Khoảng cách: {dist[end]}\r\n");
                txtKetQua.AppendText("Đường đi: " + string.Join(" ", path));

                // Hiển thị log
                txtLog.Text = log;

                // Vẽ đường đi
                TaoViTriNut();
                VeDoThiVaDuongDi(path);
            }
            catch
            {
                MessageBox.Show("Chưa nhập điểm đến và điểm đi!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<int, Point> viTriNut = new Dictionary<int, Point>();

        private void VeDoThiVaDuongDi(List<int> duongDi)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Font fontNode = new Font("Arial", 12, FontStyle.Bold))
                using (Font fontWeight = new Font("Arial", 10, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    Pen penThuong = new Pen(Color.Silver, 2);
                    Pen penDuongDi = new Pen(Color.OrangeRed, 3);


                    //  VẼ CẠNH + TRỌNG SỐ

                    foreach (var u in graph.DanhSachKe.Keys.OrderBy(x => x))
                    {
                        if (!viTriNut.ContainsKey(u)) continue;

                        foreach (var kvp in graph.DanhSachKe[u])
                        {
                            int v = kvp.Dinh;     // đỉnh kề
                            int w =(int) kvp.TrongSo;   // trọng số

                            if (u < v) // tránh vẽ trùng cạnh
                            {
                                if (!viTriNut.ContainsKey(v)) continue;

                                Point pu = viTriNut[u];
                                Point pv = viTriNut[v];

                                // Kiểm tra cạnh có thuộc đường đi không
                                bool laCanhDuongDi = false;
                                for (int i = 0; i < duongDi.Count - 1; i++)
                                {
                                    if ((duongDi[i] == u && duongDi[i + 1] == v) ||
                                        (duongDi[i] == v && duongDi[i + 1] == u))
                                    {
                                        laCanhDuongDi = true;
                                        break;
                                    }
                                }

                                Pen penVe = laCanhDuongDi ? penDuongDi : penThuong;

                                // Vẽ cạnh
                                g.DrawLine(penVe, pu, pv);


                                // TÍNH TỌA ĐỘ HIỂN THỊ TRỌNG SỐ (KHÔNG BỊ LỆCH)

                                float weightX = (pu.X + pv.X) / 2f;
                                float weightY = (pu.Y + pv.Y) / 2f;

                                PointF pos = new PointF(weightX, weightY);

                                // Vẽ trọng số
                                g.DrawString(w.ToString(), fontWeight, Brushes.DarkBlue, pos);
                            }
                        }
                    }

                  
                    //  VẼ NÚT
                
                    foreach (var v in graph.DanhSachKe.Keys)
                    {
                        if (!viTriNut.ContainsKey(v)) continue;

                        Point p = viTriNut[v];
                        Rectangle rect = new Rectangle(p.X - 18, p.Y - 18, 36, 36);

                        Brush brush = duongDi.Contains(v) ? Brushes.Gold : Brushes.LightSkyBlue;

                        g.FillEllipse(brush, rect);
                        g.DrawEllipse(Pens.Black, rect);
                        g.DrawString(v.ToString(), fontNode, Brushes.Black, rect, sf);
                    }
                }
            }

            pictureBox1.Image = bmp;
        }


        private void btnRandomGraph_Click(object sender, EventArgs e)
        {
            var dsDinh = new List<int> { 1, 2, 3, 4, 5 };
            graph = new DoThi();
            graph.TaoNgauNhien(dsDinh);
            HienThiDoThi();
        }

        private void HienThiDoThi()
        {
            dgvMatrix.Rows.Clear();
            dgvMatrix.Columns.Clear();

            foreach (var u in graph.DanhSachKe.Keys)
            {
                dgvMatrix.Columns.Add("V" + u, "V" + u);
            }

            foreach (var u in graph.DanhSachKe.Keys)
            {
                int rowIndex = dgvMatrix.Rows.Add();
                dgvMatrix.Rows[rowIndex].HeaderCell.Value = "V" + u;

                int col = 0;
                foreach (var v in graph.DanhSachKe.Keys)
                {
                    var edge = graph.DanhSachKe[u].Find(c => c.Dinh.Equals(v));
                    dgvMatrix.Rows[rowIndex].Cells[col].Value = edge != null ? edge.TrongSo : 0;
                    col++;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblKetQua_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

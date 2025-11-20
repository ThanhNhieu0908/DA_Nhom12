namespace DoAnTinHoc_Team12
{
    public partial class Form1 : Form
    {
        DoThi<int> graph;

        public Form1()
        {
            InitializeComponent();

            graph = new DoThi<int>();

            // Tạo danh sách đỉnh 1-5
            var dsDinh = new List<int> { 1, 2, 3, 4, 5 };
            graph.TaoNgauNhien(dsDinh);

            HienThiDoThi();
        }

        private void btnTinhDuongDi_Click(object sender, EventArgs e)
        {
            try
            {
                int start = int.Parse(txtStart.Text);
                int end = int.Parse(txtEnd.Text);

                var (dist, path) = DoThiDuongDi<int>.Dijkstra(graph, start, end);

                txtKetQua.Clear();
                txtKetQua.AppendText($"Khoảng cách ngắn nhất: {dist[end]}\r\n");
                txtKetQua.AppendText("Đường đi: ");
                foreach (var p in path)
                    txtKetQua.AppendText(p + " ");
            }
            catch
            {
                MessageBox.Show("Thông báo","Nhập sai! Vui lòng nhập số nguyên hợp lệ.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnRandomGraph_Click(object sender, EventArgs e)
        {
            var dsDinh = new List<int> { 1, 2, 3, 4, 5 };
            graph = new DoThi<int>();
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
                    var edge = graph.DanhSachKe[u].Find(c => c.CanhKe.Equals(v));
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
    }
}

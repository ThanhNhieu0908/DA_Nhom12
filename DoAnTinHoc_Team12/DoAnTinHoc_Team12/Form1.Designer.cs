namespace DoAnTinHoc_Team12
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Button btnRandomGraph;
        private System.Windows.Forms.Button btnTinhDuongDi;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblKetQua;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvMatrix = new DataGridView();
            txtStart = new TextBox();
            txtEnd = new TextBox();
            txtKetQua = new TextBox();
            btnRandomGraph = new Button();
            btnTinhDuongDi = new Button();
            lblStart = new Label();
            lblEnd = new Label();
            lblKetQua = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMatrix).BeginInit();
            SuspendLayout();
            // 
            // dgvMatrix
            // 
            dgvMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatrix.Location = new Point(20, 60);
            dgvMatrix.Name = "dgvMatrix";
            dgvMatrix.RowHeadersWidth = 51;
            dgvMatrix.Size = new Size(510, 310);
            dgvMatrix.TabIndex = 0;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(90, 20);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(50, 27);
            txtStart.TabIndex = 1;
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(335, 20);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(50, 27);
            txtEnd.TabIndex = 2;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(130, 408);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(400, 100);
            txtKetQua.TabIndex = 3;
            // 
            // btnRandomGraph
            // 
            btnRandomGraph.Location = new Point(589, 60);
            btnRandomGraph.Name = "btnRandomGraph";
            btnRandomGraph.Size = new Size(120, 30);
            btnRandomGraph.TabIndex = 4;
            btnRandomGraph.Text = "Tạo đồ thị Random";
            btnRandomGraph.UseVisualStyleBackColor = true;
            btnRandomGraph.Click += btnRandomGraph_Click;
            // 
            // btnTinhDuongDi
            // 
            btnTinhDuongDi.Location = new Point(589, 143);
            btnTinhDuongDi.Name = "btnTinhDuongDi";
            btnTinhDuongDi.Size = new Size(120, 30);
            btnTinhDuongDi.TabIndex = 5;
            btnTinhDuongDi.Text = "Tính đường đi";
            btnTinhDuongDi.UseVisualStyleBackColor = true;
            btnTinhDuongDi.Click += btnTinhDuongDi_Click;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(20, 23);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(60, 20);
            lblStart.TabIndex = 6;
            lblStart.Text = "Đỉnh đi:";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(225, 23);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(72, 20);
            lblEnd.TabIndex = 7;
            lblEnd.Text = "Đỉnh đến:";
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(20, 408);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(63, 20);
            lblKetQua.TabIndex = 8;
            lblKetQua.Text = "Kết quả:";
            lblKetQua.Click += lblKetQua_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1323, 613);
            Controls.Add(lblKetQua);
            Controls.Add(lblEnd);
            Controls.Add(lblStart);
            Controls.Add(btnTinhDuongDi);
            Controls.Add(btnRandomGraph);
            Controls.Add(txtKetQua);
            Controls.Add(txtEnd);
            Controls.Add(txtStart);
            Controls.Add(dgvMatrix);
            Name = "Form1";
            Text = "Tìm đường đi ngắn nhất - Dijkstra";
            ((System.ComponentModel.ISupportInitialize)dgvMatrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

namespace DoAnTinHoc_Team12
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.TextBox txtLog;

        private System.Windows.Forms.Button btnRandomGraph;
        private System.Windows.Forms.Button btnTinhDuongDi;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Label lblLog;

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
            txtLog = new TextBox();
            btnRandomGraph = new Button();
            btnTinhDuongDi = new Button();
            pictureBox1 = new PictureBox();
            lblStart = new Label();
            lblEnd = new Label();
            lblKetQua = new Label();
            lblLog = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvMatrix
            // 
            dgvMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatrix.Location = new Point(20, 60);
            dgvMatrix.Name = "dgvMatrix";
            dgvMatrix.RowHeadersWidth = 51;
            dgvMatrix.Size = new Size(669, 336);
            dgvMatrix.TabIndex = 0;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(90, 20);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(60, 27);
            txtStart.TabIndex = 1;
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(330, 20);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(60, 27);
            txtEnd.TabIndex = 3;
            // 
            // txtKetQua
            // 
            txtKetQua.Location = new Point(100, 449);
            txtKetQua.Multiline = true;
            txtKetQua.Name = "txtKetQua";
            txtKetQua.ReadOnly = true;
            txtKetQua.Size = new Size(589, 163);
            txtKetQua.TabIndex = 10;
            // 
            // txtLog
            // 
            txtLog.Font = new Font("Consolas", 10F);
            txtLog.Location = new Point(974, 41);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(481, 230);
            txtLog.TabIndex = 7;
            // 
            // btnRandomGraph
            // 
            btnRandomGraph.Location = new Point(695, 88);
            btnRandomGraph.Name = "btnRandomGraph";
            btnRandomGraph.Size = new Size(140, 32);
            btnRandomGraph.TabIndex = 4;
            btnRandomGraph.Text = "Tạo đồ thị Random";
            btnRandomGraph.Click += btnRandomGraph_Click;
            // 
            // btnTinhDuongDi
            // 
            btnTinhDuongDi.Location = new Point(695, 183);
            btnTinhDuongDi.Name = "btnTinhDuongDi";
            btnTinhDuongDi.Size = new Size(140, 32);
            btnTinhDuongDi.TabIndex = 5;
            btnTinhDuongDi.Text = "Tính đường đi";
            btnTinhDuongDi.Click += btnTinhDuongDi_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(856, 293);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(599, 444);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(20, 23);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(60, 20);
            lblStart.TabIndex = 0;
            lblStart.Text = "Đỉnh đi:";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(250, 23);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(72, 20);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "Đỉnh đến:";
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(20, 449);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(63, 20);
            lblKetQua.TabIndex = 9;
            lblKetQua.Text = "Kết quả:";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(848, 44);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(106, 20);
            lblLog.TabIndex = 6;
            lblLog.Text = "Log thuật toán";
            // 
            // Form1
            // 
            ClientSize = new Size(1488, 780);
            Controls.Add(lblStart);
            Controls.Add(txtStart);
            Controls.Add(lblEnd);
            Controls.Add(txtEnd);
            Controls.Add(dgvMatrix);
            Controls.Add(btnRandomGraph);
            Controls.Add(btnTinhDuongDi);
            Controls.Add(lblLog);
            Controls.Add(txtLog);
            Controls.Add(pictureBox1);
            Controls.Add(lblKetQua);
            Controls.Add(txtKetQua);
            Name = "Form1";
            Text = "Tìm đường đi ngắn nhất – Dijkstra";
            ((System.ComponentModel.ISupportInitialize)dgvMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

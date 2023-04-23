namespace CapaPresentacion
{
    partial class Inventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.Cbo_Inventario_Producto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_MInventario_Mostrar_Todo = new System.Windows.Forms.Button();
            this.Btn_Inventario_Consultar = new System.Windows.Forms.Button();
            this.Dgv_Inventario = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnExportarExcel = new System.Windows.Forms.Button();
            this.BtnExportarPdf = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Inventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cbo_Inventario_Producto
            // 
            this.Cbo_Inventario_Producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Inventario_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_Inventario_Producto.FormattingEnabled = true;
            this.Cbo_Inventario_Producto.Location = new System.Drawing.Point(129, 28);
            this.Cbo_Inventario_Producto.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Inventario_Producto.Name = "Cbo_Inventario_Producto";
            this.Cbo_Inventario_Producto.Size = new System.Drawing.Size(309, 24);
            this.Cbo_Inventario_Producto.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Producto";
            // 
            // Btn_MInventario_Mostrar_Todo
            // 
            this.Btn_MInventario_Mostrar_Todo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_MInventario_Mostrar_Todo.Location = new System.Drawing.Point(252, 103);
            this.Btn_MInventario_Mostrar_Todo.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_MInventario_Mostrar_Todo.Name = "Btn_MInventario_Mostrar_Todo";
            this.Btn_MInventario_Mostrar_Todo.Size = new System.Drawing.Size(100, 28);
            this.Btn_MInventario_Mostrar_Todo.TabIndex = 8;
            this.Btn_MInventario_Mostrar_Todo.Text = "Mostrar Todo";
            this.Btn_MInventario_Mostrar_Todo.UseVisualStyleBackColor = true;
            this.Btn_MInventario_Mostrar_Todo.Click += new System.EventHandler(this.Btn_MInventario_Mostrar_Todo_Click);
            // 
            // Btn_Inventario_Consultar
            // 
            this.Btn_Inventario_Consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Inventario_Consultar.Location = new System.Drawing.Point(111, 103);
            this.Btn_Inventario_Consultar.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Inventario_Consultar.Name = "Btn_Inventario_Consultar";
            this.Btn_Inventario_Consultar.Size = new System.Drawing.Size(100, 28);
            this.Btn_Inventario_Consultar.TabIndex = 7;
            this.Btn_Inventario_Consultar.Text = "Consultar";
            this.Btn_Inventario_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Inventario_Consultar.Click += new System.EventHandler(this.Btn_Inventario_Consultar_Click);
            // 
            // Dgv_Inventario
            // 
            this.Dgv_Inventario.AllowUserToResizeColumns = false;
            this.Dgv_Inventario.AllowUserToResizeRows = false;
            this.Dgv_Inventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Inventario.Location = new System.Drawing.Point(281, 247);
            this.Dgv_Inventario.Margin = new System.Windows.Forms.Padding(4);
            this.Dgv_Inventario.Name = "Dgv_Inventario";
            this.Dgv_Inventario.ReadOnly = true;
            this.Dgv_Inventario.RowHeadersWidth = 51;
            this.Dgv_Inventario.Size = new System.Drawing.Size(623, 185);
            this.Dgv_Inventario.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(548, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 25);
            this.label6.TabIndex = 35;
            this.label6.Text = "Inventario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(860, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // BtnExportarExcel
            // 
            this.BtnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportarExcel.Location = new System.Drawing.Point(31, 22);
            this.BtnExportarExcel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExportarExcel.Name = "BtnExportarExcel";
            this.BtnExportarExcel.Size = new System.Drawing.Size(180, 28);
            this.BtnExportarExcel.TabIndex = 37;
            this.BtnExportarExcel.Text = "Exportar a Excel";
            this.BtnExportarExcel.UseVisualStyleBackColor = true;
            this.BtnExportarExcel.Click += new System.EventHandler(this.BtnExportarExcel_Click);
            // 
            // BtnExportarPdf
            // 
            this.BtnExportarPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportarPdf.Location = new System.Drawing.Point(252, 22);
            this.BtnExportarPdf.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExportarPdf.Name = "BtnExportarPdf";
            this.BtnExportarPdf.Size = new System.Drawing.Size(168, 28);
            this.BtnExportarPdf.TabIndex = 38;
            this.BtnExportarPdf.Text = "Exportar a PDF";
            this.BtnExportarPdf.UseVisualStyleBackColor = true;
            this.BtnExportarPdf.Click += new System.EventHandler(this.BtnExportarPdf_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.Btn_MInventario_Mostrar_Todo);
            this.groupBox1.Controls.Add(this.Btn_Inventario_Consultar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Cbo_Inventario_Producto);
            this.groupBox1.Location = new System.Drawing.Point(373, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 160);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.BtnExportarPdf);
            this.groupBox2.Controls.Add(this.BtnExportarExcel);
            this.groupBox2.Location = new System.Drawing.Point(373, 444);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 60);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1201, 545);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Dgv_Inventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Inventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cbo_Inventario_Producto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_MInventario_Mostrar_Todo;
        private System.Windows.Forms.Button Btn_Inventario_Consultar;
        private System.Windows.Forms.DataGridView Dgv_Inventario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnExportarExcel;
        private System.Windows.Forms.Button BtnExportarPdf;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
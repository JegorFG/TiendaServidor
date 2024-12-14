namespace CapaPresentacion
{
    partial class RegistrarArtículosSucursal
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
            cmbSucursal = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtCantidadArticulos = new TextBox();
            btnRegistrarArticulosPorSucursal = new Button();
            dgvArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            SuspendLayout();
            // 
            // cmbSucursal
            // 
            cmbSucursal.FormattingEnabled = true;
            cmbSucursal.Location = new Point(90, 49);
            cmbSucursal.Name = "cmbSucursal";
            cmbSucursal.Size = new Size(234, 23);
            cmbSucursal.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 83);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 31;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 118);
            label2.Name = "label2";
            label2.Size = new Size(74, 21);
            label2.TabIndex = 30;
            label2.Text = "Artículos:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(12, 49);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 29;
            label1.Text = "Sucursal:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCantidadArticulos
            // 
            txtCantidadArticulos.Location = new Point(90, 83);
            txtCantidadArticulos.Name = "txtCantidadArticulos";
            txtCantidadArticulos.Size = new Size(234, 23);
            txtCantidadArticulos.TabIndex = 27;
            // 
            // btnRegistrarArticulosPorSucursal
            // 
            btnRegistrarArticulosPorSucursal.AccessibleName = "";
            btnRegistrarArticulosPorSucursal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarArticulosPorSucursal.Location = new Point(413, 49);
            btnRegistrarArticulosPorSucursal.Name = "btnRegistrarArticulosPorSucursal";
            btnRegistrarArticulosPorSucursal.Size = new Size(148, 30);
            btnRegistrarArticulosPorSucursal.TabIndex = 33;
            btnRegistrarArticulosPorSucursal.Text = "Registrar.";
            btnRegistrarArticulosPorSucursal.UseVisualStyleBackColor = true;
            btnRegistrarArticulosPorSucursal.Click += btnRegistrarArticulosPorSucursal_Click;
            // 
            // dgvArticulos
            // 
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticulos.Location = new Point(90, 118);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.Size = new Size(564, 282);
            dgvArticulos.TabIndex = 34;
            // 
            // RegistrarArtículosSucursal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 450);
            Controls.Add(dgvArticulos);
            Controls.Add(btnRegistrarArticulosPorSucursal);
            Controls.Add(cmbSucursal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCantidadArticulos);
            Name = "RegistrarArtículosSucursal";
            Text = "Registrar Artículos Sucursal.";
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbSucursal;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCantidadArticulos;
        private Button btnRegistrarArticulosPorSucursal;
        private DataGridView dgvArticulos;
    }
}
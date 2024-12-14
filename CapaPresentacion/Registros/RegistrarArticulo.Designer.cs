namespace CapaPresentacion
{
    partial class RegistrarArticulo
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
            btnRegistrarArticulo = new Button();
            label2 = new Label();
            label1 = new Label();
            txtDescripcionArticulo = new TextBox();
            txtIdArticulo = new TextBox();
            txtMarcaArticulo = new TextBox();
            label3 = new Label();
            cmbCategoriaArticulo = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            cmbActivoArticulo = new ComboBox();
            SuspendLayout();
            // 
            // btnRegistrarArticulo
            // 
            btnRegistrarArticulo.AccessibleName = "";
            btnRegistrarArticulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarArticulo.Location = new Point(162, 214);
            btnRegistrarArticulo.Name = "btnRegistrarArticulo";
            btnRegistrarArticulo.Size = new Size(148, 30);
            btnRegistrarArticulo.TabIndex = 14;
            btnRegistrarArticulo.Text = "Registrar Artículo.";
            btnRegistrarArticulo.UseVisualStyleBackColor = true;
            btnRegistrarArticulo.Click += btnRegistrarArticulo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 60);
            label2.Name = "label2";
            label2.Size = new Size(177, 21);
            label2.TabIndex = 12;
            label2.Text = "Descripción del Artículo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(93, 31);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 11;
            label1.Text = "ID del Artículo:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDescripcionArticulo
            // 
            txtDescripcionArticulo.Location = new Point(210, 60);
            txtDescripcionArticulo.Name = "txtDescripcionArticulo";
            txtDescripcionArticulo.Size = new Size(234, 23);
            txtDescripcionArticulo.TabIndex = 9;
            // 
            // txtIdArticulo
            // 
            txtIdArticulo.Location = new Point(210, 31);
            txtIdArticulo.Name = "txtIdArticulo";
            txtIdArticulo.Size = new Size(234, 23);
            txtIdArticulo.TabIndex = 8;
            // 
            // txtMarcaArticulo
            // 
            txtMarcaArticulo.Location = new Point(210, 118);
            txtMarcaArticulo.Name = "txtMarcaArticulo";
            txtMarcaArticulo.Size = new Size(234, 23);
            txtMarcaArticulo.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(124, 89);
            label3.Name = "label3";
            label3.Size = new Size(80, 21);
            label3.TabIndex = 13;
            label3.Text = "Categoría:";
            // 
            // cmbCategoriaArticulo
            // 
            cmbCategoriaArticulo.FormattingEnabled = true;
            cmbCategoriaArticulo.Location = new Point(210, 89);
            cmbCategoriaArticulo.Name = "cmbCategoriaArticulo";
            cmbCategoriaArticulo.Size = new Size(234, 23);
            cmbCategoriaArticulo.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(98, 147);
            label5.Name = "label5";
            label5.Size = new Size(106, 21);
            label5.TabIndex = 17;
            label5.Text = "Estado Activo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(148, 118);
            label6.Name = "label6";
            label6.Size = new Size(56, 21);
            label6.TabIndex = 16;
            label6.Text = "Marca:";
            // 
            // cmbActivoArticulo
            // 
            cmbActivoArticulo.FormattingEnabled = true;
            cmbActivoArticulo.Location = new Point(210, 147);
            cmbActivoArticulo.Name = "cmbActivoArticulo";
            cmbActivoArticulo.Size = new Size(234, 23);
            cmbActivoArticulo.TabIndex = 18;
            // 
            // RegistrarArticulo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 309);
            Controls.Add(cmbActivoArticulo);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(cmbCategoriaArticulo);
            Controls.Add(btnRegistrarArticulo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMarcaArticulo);
            Controls.Add(txtDescripcionArticulo);
            Controls.Add(txtIdArticulo);
            Name = "RegistrarArticulo";
            Text = "Registrar Articulo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrarArticulo;
        private Label label2;
        private Label label1;
        private TextBox txtDescripcionArticulo;
        private TextBox txtIdArticulo;
        private TextBox txtMarcaArticulo;
        private Label label3;
        private ComboBox cmbCategoriaArticulo;
        private Label label5;
        private Label label6;
        private ComboBox cmbActivoArticulo;
    }
}
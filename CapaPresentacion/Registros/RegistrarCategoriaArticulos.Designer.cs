namespace CapaPresentacion
{
    partial class RegistrarCategoriaArticulos
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
            btnRegistrarCategoria = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDescripcion = new TextBox();
            txtNombreCategoria = new TextBox();
            txtIdCategoria = new TextBox();
            SuspendLayout();
            // 
            // btnRegistrarCategoria
            // 
            btnRegistrarCategoria.AccessibleName = "";
            btnRegistrarCategoria.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarCategoria.Location = new Point(172, 145);
            btnRegistrarCategoria.Name = "btnRegistrarCategoria";
            btnRegistrarCategoria.Size = new Size(88, 30);
            btnRegistrarCategoria.TabIndex = 14;
            btnRegistrarCategoria.Text = "Registrar.";
            btnRegistrarCategoria.UseVisualStyleBackColor = true;
            btnRegistrarCategoria.Click += btnRegistrarCategoria_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(96, 89);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 13;
            label3.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 60);
            label2.Name = "label2";
            label2.Size = new Size(179, 21);
            label2.TabIndex = 12;
            label2.Text = "Nombre de la Categoría:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(70, 31);
            label1.Name = "label1";
            label1.Size = new Size(120, 21);
            label1.TabIndex = 11;
            label1.Text = "ID de Categoría:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(196, 87);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(225, 23);
            txtDescripcion.TabIndex = 10;
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(196, 58);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(225, 23);
            txtNombreCategoria.TabIndex = 9;
            // 
            // txtIdCategoria
            // 
            txtIdCategoria.Location = new Point(196, 29);
            txtIdCategoria.Name = "txtIdCategoria";
            txtIdCategoria.Size = new Size(225, 23);
            txtIdCategoria.TabIndex = 8;
            // 
            // RegistrarCategoriaArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 226);
            Controls.Add(btnRegistrarCategoria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDescripcion);
            Controls.Add(txtNombreCategoria);
            Controls.Add(txtIdCategoria);
            Name = "RegistrarCategoriaArticulos";
            Text = "Registrar Categoría.";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrarCategoria;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDescripcion;
        private TextBox txtNombreCategoria;
        private TextBox txtIdCategoria;
    }
}
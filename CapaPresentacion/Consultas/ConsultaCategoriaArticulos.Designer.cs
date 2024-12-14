namespace CapaPresentacion
{
    partial class ConsultaCategoriaArticulos
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
            dgvConsultaCategoriaArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaCategoriaArticulos).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaCategoriaArticulos
            // 
            dgvConsultaCategoriaArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaCategoriaArticulos.Location = new Point(12, 84);
            dgvConsultaCategoriaArticulos.Name = "dgvConsultaCategoriaArticulos";
            dgvConsultaCategoriaArticulos.Size = new Size(567, 282);
            dgvConsultaCategoriaArticulos.TabIndex = 44;
            // 
            // ConsultaCategoriaArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultaCategoriaArticulos);
            Name = "ConsultaCategoriaArticulos";
            Text = "Consulta de Categoria de Articulos";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaCategoriaArticulos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaCategoriaArticulos;
    }
}
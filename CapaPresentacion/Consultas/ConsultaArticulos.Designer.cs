namespace CapaPresentacion
{
    partial class ConsultaArticulos
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
            dgvConsultaArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaArticulos).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaArticulos
            // 
            dgvConsultaArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaArticulos.Location = new Point(12, 86);
            dgvConsultaArticulos.Name = "dgvConsultaArticulos";
            dgvConsultaArticulos.Size = new Size(567, 282);
            dgvConsultaArticulos.TabIndex = 40;
            // 
            // ConsultaArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultaArticulos);
            Name = "ConsultaArticulos";
            Text = "Consultar Articulos.";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaArticulos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaArticulos;
    }
}
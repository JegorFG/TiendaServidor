namespace CapaPresentacion
{
    partial class ConsultaAdministrador
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
            dgvConsultaAdministrador = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaAdministrador).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaAdministrador
            // 
            dgvConsultaAdministrador.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaAdministrador.Location = new Point(12, 86);
            dgvConsultaAdministrador.Name = "dgvConsultaAdministrador";
            dgvConsultaAdministrador.Size = new Size(567, 282);
            dgvConsultaAdministrador.TabIndex = 43;
            // 
            // ConsultaAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultaAdministrador);
            Name = "ConsultaAdministrador";
            Text = "Consultar Administrador.";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaAdministrador).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaAdministrador;
    }
}
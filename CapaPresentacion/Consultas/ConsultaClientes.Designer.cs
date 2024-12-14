namespace CapaPresentacion
{
    partial class ConsultaClientes
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
            dgvConsultaClientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaClientes
            // 
            dgvConsultaClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaClientes.Location = new Point(12, 86);
            dgvConsultaClientes.Name = "dgvConsultaClientes";
            dgvConsultaClientes.Size = new Size(567, 282);
            dgvConsultaClientes.TabIndex = 40;
            // 
            // ConsultaClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultaClientes);
            Name = "ConsultaClientes";
            Text = "Consultar Clientes.";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaClientes;
    }
}
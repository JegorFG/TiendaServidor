namespace CapaPresentacion
{
    partial class ConsultaArticulosSucursal
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
            dgvConsultaArticulosSucursal = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaArticulosSucursal).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaArticulosSucursal
            // 
            dgvConsultaArticulosSucursal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaArticulosSucursal.Location = new Point(12, 86);
            dgvConsultaArticulosSucursal.Name = "dgvConsultaArticulosSucursal";
            dgvConsultaArticulosSucursal.Size = new Size(567, 282);
            dgvConsultaArticulosSucursal.TabIndex = 40;
            // 
            // ConsultaArticulosSucursal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultaArticulosSucursal);
            Name = "ConsultaArticulosSucursal";
            Text = "ConsultaArticulosSucursal";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaArticulosSucursal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaArticulosSucursal;
    }
}
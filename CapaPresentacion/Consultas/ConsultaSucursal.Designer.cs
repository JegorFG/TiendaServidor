﻿namespace CapaPresentacion
{
    partial class ConsultaSucursal
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
            dgvConsultaSucursal = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaSucursal).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaSucursal
            // 
            dgvConsultaSucursal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaSucursal.Location = new Point(12, 86);
            dgvConsultaSucursal.Name = "dgvConsultaSucursal";
            dgvConsultaSucursal.Size = new Size(567, 282);
            dgvConsultaSucursal.TabIndex = 40;
            // 
            // ConsultaSucursal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvConsultaSucursal);
            Name = "ConsultaSucursal";
            Text = "Consultar Sucursal.";
            ((System.ComponentModel.ISupportInitialize)dgvConsultaSucursal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaSucursal;
    }
}
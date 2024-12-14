namespace CapaPresentacion
{
    partial class RegistrarCliente
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
            btnRegistrarCliente = new Button();
            dtpFechaNacimientoCliente = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtSegundoApellidoCliente = new TextBox();
            txtPrimerApellidoCliente = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtNombreCliente = new TextBox();
            txtIdentificacionCliente = new TextBox();
            cmbActivoCliente = new ComboBox();
            SuspendLayout();
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.AccessibleName = "";
            btnRegistrarCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarCliente.Location = new Point(125, 235);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(198, 30);
            btnRegistrarCliente.TabIndex = 38;
            btnRegistrarCliente.Text = "Registrar Cliente.";
            btnRegistrarCliente.UseVisualStyleBackColor = true;
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // dtpFechaNacimientoCliente
            // 
            dtpFechaNacimientoCliente.Location = new Point(185, 144);
            dtpFechaNacimientoCliente.Name = "dtpFechaNacimientoCliente";
            dtpFechaNacimientoCliente.Size = new Size(234, 23);
            dtpFechaNacimientoCliente.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(73, 173);
            label5.Name = "label5";
            label5.Size = new Size(106, 21);
            label5.TabIndex = 35;
            label5.Text = "Estado Activo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(24, 144);
            label6.Name = "label6";
            label6.Size = new Size(155, 21);
            label6.TabIndex = 34;
            label6.Text = "Fecha de Nacimiento";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(43, 115);
            label3.Name = "label3";
            label3.Size = new Size(136, 21);
            label3.TabIndex = 33;
            label3.Text = "Segundo Apellido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ImageAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(58, 86);
            label4.Name = "label4";
            label4.Size = new Size(121, 21);
            label4.TabIndex = 32;
            label4.Text = "Primer Apellido:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSegundoApellidoCliente
            // 
            txtSegundoApellidoCliente.Location = new Point(185, 115);
            txtSegundoApellidoCliente.Name = "txtSegundoApellidoCliente";
            txtSegundoApellidoCliente.Size = new Size(234, 23);
            txtSegundoApellidoCliente.TabIndex = 31;
            // 
            // txtPrimerApellidoCliente
            // 
            txtPrimerApellidoCliente.Location = new Point(185, 86);
            txtPrimerApellidoCliente.Name = "txtPrimerApellidoCliente";
            txtPrimerApellidoCliente.Size = new Size(234, 23);
            txtPrimerApellidoCliente.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(108, 57);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 29;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(74, 28);
            label1.Name = "label1";
            label1.Size = new Size(105, 21);
            label1.TabIndex = 28;
            label1.Text = "ID del Cliente:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(185, 57);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(234, 23);
            txtNombreCliente.TabIndex = 27;
            // 
            // txtIdentificacionCliente
            // 
            txtIdentificacionCliente.Location = new Point(185, 28);
            txtIdentificacionCliente.Name = "txtIdentificacionCliente";
            txtIdentificacionCliente.Size = new Size(234, 23);
            txtIdentificacionCliente.TabIndex = 26;
            // 
            // cmbActivoCliente
            // 
            cmbActivoCliente.FormattingEnabled = true;
            cmbActivoCliente.Location = new Point(185, 173);
            cmbActivoCliente.Name = "cmbActivoCliente";
            cmbActivoCliente.Size = new Size(234, 23);
            cmbActivoCliente.TabIndex = 39;
            // 
            // RegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 300);
            Controls.Add(cmbActivoCliente);
            Controls.Add(btnRegistrarCliente);
            Controls.Add(dtpFechaNacimientoCliente);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtSegundoApellidoCliente);
            Controls.Add(txtPrimerApellidoCliente);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombreCliente);
            Controls.Add(txtIdentificacionCliente);
            Name = "RegistrarCliente";
            Text = "RegistrarCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrarCliente;
        private DateTimePicker dtpFechaNacimientoCliente;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private TextBox txtSegundoApellidoCliente;
        private TextBox txtPrimerApellidoCliente;
        private Label label2;
        private Label label1;
        private TextBox txtNombreCliente;
        private TextBox txtIdentificacionCliente;
        private ComboBox cmbActivoCliente;
    }
}
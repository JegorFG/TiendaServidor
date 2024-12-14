namespace CapaPresentacion
{
    partial class RegistrarAdministrador
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
            label2 = new Label();
            label1 = new Label();
            txtNombreAdministrador = new TextBox();
            txtIdentificacion = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtSegundoApellidoAdministrador = new TextBox();
            txtPrimerApellidoAdministrador = new TextBox();
            label5 = new Label();
            label6 = new Label();
            dtpFechaNacimientoAdministrador = new DateTimePicker();
            dtpFechaIngresoAdministrador = new DateTimePicker();
            btnRegistrarAdministrador = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(148, 65);
            label2.Name = "label2";
            label2.Size = new Size(71, 21);
            label2.TabIndex = 16;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(62, 36);
            label1.Name = "label1";
            label1.Size = new Size(157, 21);
            label1.TabIndex = 15;
            label1.Text = "ID del Administrador:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombreAdministrador
            // 
            txtNombreAdministrador.Location = new Point(225, 65);
            txtNombreAdministrador.Name = "txtNombreAdministrador";
            txtNombreAdministrador.Size = new Size(234, 23);
            txtNombreAdministrador.TabIndex = 14;
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(225, 36);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(234, 23);
            txtIdentificacion.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(83, 123);
            label3.Name = "label3";
            label3.Size = new Size(136, 21);
            label3.TabIndex = 20;
            label3.Text = "Segundo Apellido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ImageAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(98, 94);
            label4.Name = "label4";
            label4.Size = new Size(121, 21);
            label4.TabIndex = 19;
            label4.Text = "Primer Apellido:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtSegundoApellidoAdministrador
            // 
            txtSegundoApellidoAdministrador.Location = new Point(225, 123);
            txtSegundoApellidoAdministrador.Name = "txtSegundoApellidoAdministrador";
            txtSegundoApellidoAdministrador.Size = new Size(234, 23);
            txtSegundoApellidoAdministrador.TabIndex = 18;
            // 
            // txtPrimerApellidoAdministrador
            // 
            txtPrimerApellidoAdministrador.Location = new Point(225, 94);
            txtPrimerApellidoAdministrador.Name = "txtPrimerApellidoAdministrador";
            txtPrimerApellidoAdministrador.Size = new Size(234, 23);
            txtPrimerApellidoAdministrador.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(89, 181);
            label5.Name = "label5";
            label5.Size = new Size(130, 21);
            label5.TabIndex = 22;
            label5.Text = "Fecha de Ingreso:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ImageAlign = ContentAlignment.MiddleRight;
            label6.Location = new Point(64, 152);
            label6.Name = "label6";
            label6.Size = new Size(155, 21);
            label6.TabIndex = 21;
            label6.Text = "Fecha de Nacimiento";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpFechaNacimientoAdministrador
            // 
            dtpFechaNacimientoAdministrador.Location = new Point(225, 152);
            dtpFechaNacimientoAdministrador.Name = "dtpFechaNacimientoAdministrador";
            dtpFechaNacimientoAdministrador.Size = new Size(234, 23);
            dtpFechaNacimientoAdministrador.TabIndex = 23;
            // 
            // dtpFechaIngresoAdministrador
            // 
            dtpFechaIngresoAdministrador.Location = new Point(225, 181);
            dtpFechaIngresoAdministrador.Name = "dtpFechaIngresoAdministrador";
            dtpFechaIngresoAdministrador.Size = new Size(234, 23);
            dtpFechaIngresoAdministrador.TabIndex = 24;
            // 
            // btnRegistrarAdministrador
            // 
            btnRegistrarAdministrador.AccessibleName = "";
            btnRegistrarAdministrador.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarAdministrador.Location = new Point(165, 243);
            btnRegistrarAdministrador.Name = "btnRegistrarAdministrador";
            btnRegistrarAdministrador.Size = new Size(198, 30);
            btnRegistrarAdministrador.TabIndex = 25;
            btnRegistrarAdministrador.Text = "Registrar Administrador.";
            btnRegistrarAdministrador.UseVisualStyleBackColor = true;
            btnRegistrarAdministrador.Click += btnRegistrarAdministrador_Click;
            // 
            // RegistrarAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 342);
            Controls.Add(btnRegistrarAdministrador);
            Controls.Add(dtpFechaIngresoAdministrador);
            Controls.Add(dtpFechaNacimientoAdministrador);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(txtSegundoApellidoAdministrador);
            Controls.Add(txtPrimerApellidoAdministrador);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombreAdministrador);
            Controls.Add(txtIdentificacion);
            Name = "RegistrarAdministrador";
            Text = "Registrar Administrador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox txtIdentificacion;
        private TextBox txtNombreAdministrador;
        private Label label3;
        private Label label4;
        private TextBox txtPrimerApellidoAdministrador;
        private TextBox txtSegundoApellidoAdministrador;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpFechaNacimientoAdministrador;
        private DateTimePicker dtpFechaIngresoAdministrador;
        private Button btnRegistrarAdministrador;
    }
}
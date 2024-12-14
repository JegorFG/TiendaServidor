namespace Servidor
{
    partial class FormServidor
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
            menuStrip1 = new MenuStrip();
            msServidor = new ToolStripMenuItem();
            consultarToolStripMenuItem = new ToolStripMenuItem();
            tsConsultarAdministrador = new ToolStripMenuItem();
            tsRegistrarAdministrador = new ToolStripMenuItem();
            artículosToolStripMenuItem1 = new ToolStripMenuItem();
            tsConsultarArticulos = new ToolStripMenuItem();
            tsRegistrarArticulos = new ToolStripMenuItem();
            artículosPorSucursalToolStripMenuItem1 = new ToolStripMenuItem();
            tsConsultarArticulosSucursal = new ToolStripMenuItem();
            tsRegistrarArticulosSucursal = new ToolStripMenuItem();
            categoríaDeArtículosToolStripMenuItem1 = new ToolStripMenuItem();
            tsConsultarCategoríaArticulos = new ToolStripMenuItem();
            tsRegistrarCategoríaArticulos = new ToolStripMenuItem();
            clienteToolStripMenuItem1 = new ToolStripMenuItem();
            tsConsultarCliente = new ToolStripMenuItem();
            tsRegistrarCliente = new ToolStripMenuItem();
            sucursalToolStripMenuItem1 = new ToolStripMenuItem();
            tsConsultarSucursal = new ToolStripMenuItem();
            tsRegistrarSucursal = new ToolStripMenuItem();
            btnDetenerServidor = new Button();
            btnIniciarServidor = new Button();
            lbServidor = new Label();
            lstBitacora = new ListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { msServidor });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1028, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // msServidor
            // 
            msServidor.DropDownItems.AddRange(new ToolStripItem[] { consultarToolStripMenuItem, artículosToolStripMenuItem1, artículosPorSucursalToolStripMenuItem1, categoríaDeArtículosToolStripMenuItem1, clienteToolStripMenuItem1, sucursalToolStripMenuItem1 });
            msServidor.Name = "msServidor";
            msServidor.Size = new Size(131, 20);
            msServidor.Text = "Consultas y Registros";
            // 
            // consultarToolStripMenuItem
            // 
            consultarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsConsultarAdministrador, tsRegistrarAdministrador });
            consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            consultarToolStripMenuItem.Size = new Size(191, 22);
            consultarToolStripMenuItem.Text = "Administrador ";
            // 
            // tsConsultarAdministrador
            // 
            tsConsultarAdministrador.Name = "tsConsultarAdministrador";
            tsConsultarAdministrador.Size = new Size(204, 22);
            tsConsultarAdministrador.Text = "Consultar Administrador";
            tsConsultarAdministrador.Click += tsConsultarAdministrador_Click;
            // 
            // tsRegistrarAdministrador
            // 
            tsRegistrarAdministrador.Name = "tsRegistrarAdministrador";
            tsRegistrarAdministrador.Size = new Size(204, 22);
            tsRegistrarAdministrador.Text = "Registrar Administrador";
            tsRegistrarAdministrador.Click += tsRegistrarAdministrador_Click;
            // 
            // artículosToolStripMenuItem1
            // 
            artículosToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { tsConsultarArticulos, tsRegistrarArticulos });
            artículosToolStripMenuItem1.Name = "artículosToolStripMenuItem1";
            artículosToolStripMenuItem1.Size = new Size(191, 22);
            artículosToolStripMenuItem1.Text = "Artículos";
            // 
            // tsConsultarArticulos
            // 
            tsConsultarArticulos.Name = "tsConsultarArticulos";
            tsConsultarArticulos.Size = new Size(175, 22);
            tsConsultarArticulos.Text = "Consultar Artículos";
            tsConsultarArticulos.Click += tsConsultarArticulos_Click;
            // 
            // tsRegistrarArticulos
            // 
            tsRegistrarArticulos.Name = "tsRegistrarArticulos";
            tsRegistrarArticulos.Size = new Size(175, 22);
            tsRegistrarArticulos.Text = "Registrar Artículos";
            tsRegistrarArticulos.Click += tsRegistrarArticulos_Click;
            // 
            // artículosPorSucursalToolStripMenuItem1
            // 
            artículosPorSucursalToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { tsConsultarArticulosSucursal, tsRegistrarArticulosSucursal });
            artículosPorSucursalToolStripMenuItem1.Name = "artículosPorSucursalToolStripMenuItem1";
            artículosPorSucursalToolStripMenuItem1.Size = new Size(191, 22);
            artículosPorSucursalToolStripMenuItem1.Text = "Artículos por Sucursal";
            // 
            // tsConsultarArticulosSucursal
            // 
            tsConsultarArticulosSucursal.Name = "tsConsultarArticulosSucursal";
            tsConsultarArticulosSucursal.Size = new Size(243, 22);
            tsConsultarArticulosSucursal.Text = "Consultar Artículos por Sucursal";
            tsConsultarArticulosSucursal.Click += tsConsultarArticulosSucursal_Click;
            // 
            // tsRegistrarArticulosSucursal
            // 
            tsRegistrarArticulosSucursal.Name = "tsRegistrarArticulosSucursal";
            tsRegistrarArticulosSucursal.Size = new Size(243, 22);
            tsRegistrarArticulosSucursal.Text = "Registrar Artículos por Sucursal";
            tsRegistrarArticulosSucursal.Click += tsRegistrarArticulosSucursal_Click;
            // 
            // categoríaDeArtículosToolStripMenuItem1
            // 
            categoríaDeArtículosToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { tsConsultarCategoríaArticulos, tsRegistrarCategoríaArticulos });
            categoríaDeArtículosToolStripMenuItem1.Name = "categoríaDeArtículosToolStripMenuItem1";
            categoríaDeArtículosToolStripMenuItem1.Size = new Size(191, 22);
            categoríaDeArtículosToolStripMenuItem1.Text = "Categoría de Artículos";
            // 
            // tsConsultarCategoríaArticulos
            // 
            tsConsultarCategoríaArticulos.Name = "tsConsultarCategoríaArticulos";
            tsConsultarCategoríaArticulos.Size = new Size(245, 22);
            tsConsultarCategoríaArticulos.Text = "Consultar Categoría de Artículos";
            tsConsultarCategoríaArticulos.Click += tsConsultarCategoríaArticulos_Click;
            // 
            // tsRegistrarCategoríaArticulos
            // 
            tsRegistrarCategoríaArticulos.Name = "tsRegistrarCategoríaArticulos";
            tsRegistrarCategoríaArticulos.Size = new Size(245, 22);
            tsRegistrarCategoríaArticulos.Text = "Registrar Categoría de Artículos";
            tsRegistrarCategoríaArticulos.Click += tsRegistrarCategoríaArticulos_Click;
            // 
            // clienteToolStripMenuItem1
            // 
            clienteToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { tsConsultarCliente, tsRegistrarCliente });
            clienteToolStripMenuItem1.Name = "clienteToolStripMenuItem1";
            clienteToolStripMenuItem1.Size = new Size(191, 22);
            clienteToolStripMenuItem1.Text = "Cliente";
            // 
            // tsConsultarCliente
            // 
            tsConsultarCliente.Name = "tsConsultarCliente";
            tsConsultarCliente.Size = new Size(180, 22);
            tsConsultarCliente.Text = "Consultar Cliente";
            tsConsultarCliente.Click += tsConsultarCliente_Click;
            // 
            // tsRegistrarCliente
            // 
            tsRegistrarCliente.Name = "tsRegistrarCliente";
            tsRegistrarCliente.Size = new Size(180, 22);
            tsRegistrarCliente.Text = "Registrar Cliente";
            tsRegistrarCliente.Click += tsRegistrarCliente_Click;
            // 
            // sucursalToolStripMenuItem1
            // 
            sucursalToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { tsConsultarSucursal, tsRegistrarSucursal });
            sucursalToolStripMenuItem1.Name = "sucursalToolStripMenuItem1";
            sucursalToolStripMenuItem1.Size = new Size(191, 22);
            sucursalToolStripMenuItem1.Text = "Sucursal";
            // 
            // tsConsultarSucursal
            // 
            tsConsultarSucursal.Name = "tsConsultarSucursal";
            tsConsultarSucursal.Size = new Size(180, 22);
            tsConsultarSucursal.Text = "Consultar Sucursal";
            tsConsultarSucursal.Click += tsConsultarSucursal_Click;
            // 
            // tsRegistrarSucursal
            // 
            tsRegistrarSucursal.Name = "tsRegistrarSucursal";
            tsRegistrarSucursal.Size = new Size(180, 22);
            tsRegistrarSucursal.Text = "Registrar Sucursal";
            tsRegistrarSucursal.Click += tsRegistrarSucursal_Click;
            // 
            // btnDetenerServidor
            // 
            btnDetenerServidor.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnDetenerServidor.Location = new Point(799, 321);
            btnDetenerServidor.Name = "btnDetenerServidor";
            btnDetenerServidor.Size = new Size(194, 51);
            btnDetenerServidor.TabIndex = 8;
            btnDetenerServidor.Text = "Detener Servidor.";
            btnDetenerServidor.UseVisualStyleBackColor = true;
            btnDetenerServidor.Click += btnDetenerServidor_Click;
            // 
            // btnIniciarServidor
            // 
            btnIniciarServidor.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            btnIniciarServidor.Location = new Point(799, 199);
            btnIniciarServidor.Name = "btnIniciarServidor";
            btnIniciarServidor.Size = new Size(194, 51);
            btnIniciarServidor.TabIndex = 7;
            btnIniciarServidor.Text = "Iniciar Servidor.";
            btnIniciarServidor.UseVisualStyleBackColor = true;
            btnIniciarServidor.Click += btnIniciarServidor_Click;
            // 
            // lbServidor
            // 
            lbServidor.AutoSize = true;
            lbServidor.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lbServidor.Location = new Point(668, 101);
            lbServidor.Name = "lbServidor";
            lbServidor.Size = new Size(31, 30);
            lbServidor.TabIndex = 6;
            lbServidor.Text = "--";
            // 
            // lstBitacora
            // 
            lstBitacora.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lstBitacora.FormattingEnabled = true;
            lstBitacora.ItemHeight = 30;
            lstBitacora.Location = new Point(12, 101);
            lstBitacora.Name = "lstBitacora";
            lstBitacora.Size = new Size(650, 484);
            lstBitacora.TabIndex = 5;
            // 
            // FormServidor
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 630);
            Controls.Add(menuStrip1);
            Controls.Add(btnDetenerServidor);
            Controls.Add(btnIniciarServidor);
            Controls.Add(lbServidor);
            Controls.Add(lstBitacora);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormServidor";
            Text = "FormServidor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem msServidor;
        private ToolStripMenuItem consultarToolStripMenuItem;
        private ToolStripMenuItem tsRegistrarAdministrador;
        private ToolStripMenuItem artículosToolStripMenuItem1;
        private ToolStripMenuItem tsConsultarArticulos;
        private ToolStripMenuItem tsRegistrarArticulos;
        private ToolStripMenuItem artículosPorSucursalToolStripMenuItem1;
        private ToolStripMenuItem tsConsultarArticulosSucursal;
        private ToolStripMenuItem tsRegistrarArticulosSucursal;
        private ToolStripMenuItem categoríaDeArtículosToolStripMenuItem1;
        private ToolStripMenuItem tsConsultarCategoríaArticulos;
        private ToolStripMenuItem tsRegistrarCategoríaArticulos;
        private ToolStripMenuItem clienteToolStripMenuItem1;
        private ToolStripMenuItem tsConsultarCliente;
        private ToolStripMenuItem tsRegistrarCliente;
        private ToolStripMenuItem sucursalToolStripMenuItem1;
        private ToolStripMenuItem tsConsultarSucursal;
        private ToolStripMenuItem tsRegistrarSucursal;
        private Button btnDetenerServidor;
        private Button btnIniciarServidor;
        private Label lbServidor;
        private ListBox lstBitacora;
        private ToolStripMenuItem tsConsultarAdministrador;
    }
}
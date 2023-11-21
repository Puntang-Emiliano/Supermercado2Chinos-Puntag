namespace Supermercado2Chinos
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenimiento = new FontAwesome.Sharp.IconMenuItem();
            this.submenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.submenuProducto = new FontAwesome.Sharp.IconMenuItem();
            this.submenusupermercado = new System.Windows.Forms.ToolStripMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistrarVentas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleVenta = new FontAwesome.Sharp.IconMenuItem();
            this.submenuInformeVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegitarCompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenuDetalleCompra = new FontAwesome.Sharp.IconMenuItem();
            this.submeninformeCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedor = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuarios,
            this.menumantenimiento,
            this.menuventas,
            this.menucompras,
            this.menuclientes,
            this.menuproveedor,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 64);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(887, 73);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip2";
            // 
            // menuusuarios
            // 
            this.menuusuarios.AutoSize = false;
            this.menuusuarios.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.menuusuarios.IconColor = System.Drawing.Color.Black;
            this.menuusuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuarios.IconSize = 50;
            this.menuusuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuarios.Name = "menuusuarios";
            this.menuusuarios.Size = new System.Drawing.Size(80, 69);
            this.menuusuarios.Text = "Usuarios";
            this.menuusuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuarios.Click += new System.EventHandler(this.menuusuario_Click);
            // 
            // menumantenimiento
            // 
            this.menumantenimiento.AutoSize = false;
            this.menumantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuCategoria,
            this.submenuProducto,
            this.submenusupermercado});
            this.menumantenimiento.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menumantenimiento.IconColor = System.Drawing.Color.Black;
            this.menumantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenimiento.IconSize = 50;
            this.menumantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenimiento.Name = "menumantenimiento";
            this.menumantenimiento.Size = new System.Drawing.Size(122, 69);
            this.menumantenimiento.Text = "Mantenimiento";
            this.menumantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuCategoria
            // 
            this.submenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuCategoria.IconColor = System.Drawing.Color.Black;
            this.submenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuCategoria.Name = "submenuCategoria";
            this.submenuCategoria.Size = new System.Drawing.Size(151, 22);
            this.submenuCategoria.Text = "Categorias";
            this.submenuCategoria.Click += new System.EventHandler(this.submenuCategoria_Click);
            // 
            // submenuProducto
            // 
            this.submenuProducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuProducto.IconColor = System.Drawing.Color.Black;
            this.submenuProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuProducto.Name = "submenuProducto";
            this.submenuProducto.Size = new System.Drawing.Size(151, 22);
            this.submenuProducto.Text = "Producto";
            this.submenuProducto.Click += new System.EventHandler(this.submenuProducto_Click);
            // 
            // submenusupermercado
            // 
            this.submenusupermercado.Name = "submenusupermercado";
            this.submenusupermercado.Size = new System.Drawing.Size(151, 22);
            this.submenusupermercado.Text = "Supermercado";
            this.submenusupermercado.Click += new System.EventHandler(this.submenusupermercado_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistrarVentas,
            this.submenuDetalleVenta,
            this.submenuInformeVentas});
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 50;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(80, 69);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegistrarVentas
            // 
            this.submenuRegistrarVentas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistrarVentas.IconColor = System.Drawing.Color.Black;
            this.submenuRegistrarVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistrarVentas.Name = "submenuRegistrarVentas";
            this.submenuRegistrarVentas.Size = new System.Drawing.Size(153, 22);
            this.submenuRegistrarVentas.Text = "Registrar Venta";
            this.submenuRegistrarVentas.Click += new System.EventHandler(this.submenuRegistrarVentas_Click);
            // 
            // submenuDetalleVenta
            // 
            this.submenuDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleVenta.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleVenta.Name = "submenuDetalleVenta";
            this.submenuDetalleVenta.Size = new System.Drawing.Size(153, 22);
            this.submenuDetalleVenta.Text = "Detalle Venta";
            this.submenuDetalleVenta.Click += new System.EventHandler(this.submenuDetalleVenta_Click);
            // 
            // submenuInformeVentas
            // 
            this.submenuInformeVentas.Name = "submenuInformeVentas";
            this.submenuInformeVentas.Size = new System.Drawing.Size(153, 22);
            this.submenuInformeVentas.Text = "Informe Ventas";
            this.submenuInformeVentas.Click += new System.EventHandler(this.submenuInformeVentas_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegitarCompra,
            this.submenuDetalleCompra,
            this.submeninformeCompras});
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.Dolly;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 50;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.Size = new System.Drawing.Size(80, 69);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuRegitarCompra
            // 
            this.submenuRegitarCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegitarCompra.IconColor = System.Drawing.Color.Black;
            this.submenuRegitarCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegitarCompra.Name = "submenuRegitarCompra";
            this.submenuRegitarCompra.Size = new System.Drawing.Size(167, 22);
            this.submenuRegitarCompra.Text = "Registrar Compra";
            this.submenuRegitarCompra.Click += new System.EventHandler(this.submenuRegitarCompra_Click);
            // 
            // submenuDetalleCompra
            // 
            this.submenuDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuDetalleCompra.IconColor = System.Drawing.Color.Black;
            this.submenuDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuDetalleCompra.Name = "submenuDetalleCompra";
            this.submenuDetalleCompra.Size = new System.Drawing.Size(167, 22);
            this.submenuDetalleCompra.Text = "Detalle Compra";
            this.submenuDetalleCompra.Click += new System.EventHandler(this.submenuDetalleCompra_Click);
            // 
            // submeninformeCompras
            // 
            this.submeninformeCompras.Name = "submeninformeCompras";
            this.submeninformeCompras.Size = new System.Drawing.Size(167, 22);
            this.submeninformeCompras.Text = "Informe Compras";
            this.submeninformeCompras.Click += new System.EventHandler(this.submeninformeCompras_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 50;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(80, 69);
            this.menuclientes.Text = "Cliente";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menucliente_Click);
            // 
            // menuproveedor
            // 
            this.menuproveedor.AutoSize = false;
            this.menuproveedor.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuproveedor.IconColor = System.Drawing.Color.Black;
            this.menuproveedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedor.IconSize = 50;
            this.menuproveedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedor.Name = "menuproveedor";
            this.menuproveedor.Size = new System.Drawing.Size(80, 69);
            this.menuproveedor.Text = "Proveedores";
            this.menuproveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproveedor.Click += new System.EventHandler(this.menuproveedor_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.Camera;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(80, 69);
            this.menuacercade.Text = "Camara";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacercade.Click += new System.EventHandler(this.menuacercade_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.Silver;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(887, 64);
            this.menutitulo.TabIndex = 2;
            this.menutitulo.Text = "menuStrip3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(108, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Supermercado Los 2 Chinos";
            // 
            // Contenedor
            // 
            this.Contenedor.AutoSize = true;
            this.Contenedor.BackColor = System.Drawing.Color.Silver;
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 137);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(887, 279);
            this.Contenedor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(474, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.Silver;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.Black;
            this.lblusuario.Location = new System.Drawing.Point(541, 28);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(73, 17);
            this.lblusuario.TabIndex = 6;
            this.lblusuario.Text = "lblusuario:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 416);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private FontAwesome.Sharp.IconMenuItem menuusuarios;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menumantenimiento;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuproveedor;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private FontAwesome.Sharp.IconMenuItem submenuCategoria;
        private FontAwesome.Sharp.IconMenuItem submenuProducto;
        private FontAwesome.Sharp.IconMenuItem submenuRegistrarVentas;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleVenta;
        private FontAwesome.Sharp.IconMenuItem submenuRegitarCompra;
        private FontAwesome.Sharp.IconMenuItem submenuDetalleCompra;
        private System.Windows.Forms.ToolStripMenuItem submenusupermercado;
        private System.Windows.Forms.ToolStripMenuItem submenuInformeVentas;
        private System.Windows.Forms.ToolStripMenuItem submeninformeCompras;
    }
}


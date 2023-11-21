using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Windows;
using CapaNegocio;
using System.Windows;

namespace Supermercado2Chinos
{
    public partial class Inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;


        public Inicio(Usuario objusuario= null)
        {
            if (objusuario == null) usuarioActual = new Usuario() // ESTE IF EVTA EL INICIO DE SESION
            { NombreCompleto = "ADMIN PRED", IdUsuario = 1 };     //  
            else 
            usuarioActual = objusuario;

            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso>ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(x => x.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }

            }

            lblusuario.Text = usuarioActual.NombreCompleto;

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;

            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;


            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.RoyalBlue;

            Contenedor.Controls.Add(formulario);
            formulario.Show();

        }




        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new fmrUsuarios());

        }

        private void submenuCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new fmrCategoria());

        }

        private void submenuProducto_Click(object sender, EventArgs e)
        {

            AbrirFormulario(menumantenimiento, new fmrProducto());
        }

        private void submenuRegistrarVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new fmrVentas(usuarioActual));

        }

        private void submenuDetalleVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new fmrDetalleVenta());
        }

        private void submenuRegitarCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new fmrCompras(usuarioActual));

        }

        private void submenuDetalleCompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new fmrDetalleCompra());
        }

        private void menucliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new fmrClientes());
        }

        private void menuproveedor_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new fmrProveedores());
        }

        

        private void menuacercade_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCamara());
        }

        private void submenusupermercado_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new frmNegocio());

        }

        private void submeninformeCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new FrmInformeCompras());
        }

        private void submenuInformeVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new FrmInformeVentas());
        }

      
    }

}
